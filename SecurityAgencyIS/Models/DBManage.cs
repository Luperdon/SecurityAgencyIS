using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Security.Cryptography;
using System.Net.Http.Json;
using Newtonsoft.Json;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace SecurityAgencyIS.Models
{
    public class DBManage
    {
        public string connectionString = "Server=localhost;Port=5432;Database=SecurityAgencyDB;User id=postgres;Password=1234;";
        public string jsonFilePath = "C:\\Users\\ilcat\\source\\repos\\SecurityAgencyIS\\SecurityAgencyIS\\View\\EditingWindows\\Voorhees.json";
        private string jsonContent;
        public void SqlConnectionReader(DataGridView dataGridView1)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM events";
            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;
            }

            command.Dispose();
            conn.Close();
        }

        public void InsertUser(string login, string password, string role, string salt)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO users (userlogin, userpassword, roles, salt) VALUES (@userlogin, @userpassword, @roles, @salt)";

            command.Parameters.AddWithValue("@userlogin", login);
            command.Parameters.AddWithValue("@userpassword", password);
            command.Parameters.AddWithValue("@roles", role);
            command.Parameters.AddWithValue("@salt", salt);

            command.ExecuteNonQuery();
        }

        public bool UserExists(string login)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT COUNT(*) FROM users WHERE userlogin = @userlogin";

                    command.Parameters.AddWithValue("@userlogin", login);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void Add(string[] data, string tablename)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            jsonContent = File.ReadAllText(jsonFilePath);
            dynamic tables = JsonConvert.DeserializeObject(jsonContent);
            string sql = $"INSERT INTO {tablename} (";
            try
            {
                foreach (var table in tables)
                {
                    if (table.table_name == tablename)
                    {
                        var columns = table.columns;
                        var lastcolum = columns.Last;
                        string minizapros = " ";
                        foreach (var column in table.columns)
                        {
                            minizapros = column.column_name;
                            if (column != lastcolum)
                            {
                                minizapros += ", ";
                            }
                            sql += minizapros;
                        }
                        sql += ") VALUES (";
                        int i = 0;

                        foreach (var column in table.columns)
                        {
                            if (column.references != null)
                            {
                                var refer = column.references;

                                string paramname = $"@param{i}";
                                sql += paramname;

                                if (column != lastcolum)
                                {
                                    sql += ", ";
                                }
                                string rtable = refer.table != null ? refer.table.ToString() : "";
                                string Replece = refer.replace_with != null ? refer.replace_with.ToString() : "";
                                int? id = FindIdByType(rtable, Replece, data[i]);
                                if (!id.HasValue)
                                {
                                    MessageBox.Show("No ID found.");
                                }

                                command.Parameters.AddWithValue(paramname, id);
                            }
                            else
                            {
                                string paramname = $"@param{i}";
                                sql += paramname;

                                if (column != lastcolum)
                                {
                                    sql += ", ";
                                }
                                string columnType = column.type != null ? column.type.ToString() : "";
                                object r = ReturnType(columnType, data[i]);
                                command.Parameters.AddWithValue(paramname, r);
                            }
                            i++;
                        }
                        sql += ");";
                    }
                }
                command.CommandText = sql;
                command.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Записи успешно внесены таблицу, поспешите их проверить! :)", "Успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Ошибка :(");
            }
        }
        public int? FindIdByType(string tablename, string columnName, object value)
        {
            using (var command1 = new NpgsqlCommand())
            {
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                command1.Connection = conn;

                command1.CommandText = $"SELECT id FROM {tablename} WHERE {columnName} = @value";

                command1.Parameters.AddWithValue("@value", value);
                conn.Open();
                using (var reader = command1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }
            return null;
        }

        public object ReturnType(string obj, string name)
        {
            object ob = null;
            switch (obj)
            {
                case "integer":
                    ob = Convert.ToInt32(name);
                    break;
                case "text":
                    ob = name;
                    break;
                case "date":
                    ob = Convert.ToDateTime(name);
                    break;
                case "boolean":
                    ob = Convert.ToBoolean(name);
                    break;
                case "double":
                    ob = Convert.ToDouble(name);
                    break;
                default:
                    throw new Exception($"Unsupported type: ");
            }
            return ob;
        }

        public void Update(string tablename, string[] update)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            command.Connection = conn;
            conn.Open();
            command.CommandType = CommandType.Text;
            jsonContent = File.ReadAllText(jsonFilePath);
            dynamic tables = JsonConvert.DeserializeObject(jsonContent);

            string sql = $"UPDATE {tablename} SET ";
            int i = 0;
            string idparam = "@idparam";
            string Where = $" WHERE id = {idparam};";

            // Проверяем ID
            if (!int.TryParse(update[0], out int id))
            {
                throw new Exception("ID должен быть числом.");
            }
            command.Parameters.AddWithValue(idparam, id);
            i++;

            try
            {
                foreach (var table in tables)
                {
                    if (table.table_name == tablename)
                    {
                        var columns = table.columns;
                        var lastcolum = columns.Last;

                        foreach (var column in columns)
                        {
                            if (column.primary_key != null) continue;

                            string paramname = $"@param{i}";
                            string columnName = column.column_name.ToString();
                            string columnType = column.type != null ? column.type.ToString() : "";

                            if (string.IsNullOrWhiteSpace(update[i]))
                            {
                                i++;
                                continue;
                            }

                            object value = ReturnType(columnType, update[i]);
                            command.Parameters.AddWithValue(paramname, value);

                            sql += $"{columnName} = {paramname}";
                            if (column != lastcolum)
                            {
                                sql += ", ";
                            }
                            i++;
                        }
                    }
                }

                sql += Where;

                // Логирование SQL-запроса
                //MessageBox.Show($"SQL-запрос: {sql}");
                //foreach (NpgsqlParameter param in command.Parameters)
                //{
                //    MessageBox.Show($"Параметр: {param.ParameterName}, Значение: {param.Value}");
                //}

                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            finally
            {
                command.Dispose();
                conn.Close();
            }
        }

        public void Delete(string tablename, string column, string data)
        {
            string sql = $"DELETE FROM {tablename} WHERE {column} = {data};";
        }
        public void Delete(string tablename, int id)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand();
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                command.Connection = conn;
                conn.Open();
                command.CommandType = CommandType.Text;
                string sql = $"DELETE FROM {tablename} WHERE id = @id;";

                command.Parameters.AddWithValue("@id", id);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Данные удалены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Find(string columna, string tablename, string data, DataGridView d)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            command.Connection = conn;
            conn.Open();
            command.CommandType = CommandType.Text;
            string a = "@where";

            string where = $"WHERE ";
            try
            {
                dynamic tables = JsonConvert.DeserializeObject(jsonContent);
                string sql = "";
                foreach (var table in tables)
                {
                    if (table.table_name == tablename)
                    {
                        var columns = table.columns;
                        var lastcolum = columns.Last;
                        sql = $"SELECT ";

                        foreach (var column in table.columns)
                        {
                            if (column.references != null)
                            {
                                var refer = column.references;
                                sql += $"{refer.table}.{refer.replace_with} AS {column.lname}";
                                string s = column.column_name.ToString();
                                if (columna == s)
                                {
                                    string rtable = refer.table != null ? refer.table.ToString() : "";
                                    string Replece = refer.replace_with != null ? refer.replace_with.ToString() : "";
                                    string refertype = refer.type != null ? refer.type.ToString() : "";
                                    object rr;
                                    if (refertype == "text")
                                    {
                                        string pattern = $"%{data}%";
                                        command.Parameters.AddWithValue(a, pattern);
                                        where += $" {refer.table}.{Replece} LIKE {a} ";
                                    }
                                    else
                                    {

                                        try
                                        {
                                            rr = ReturnType(refertype, data);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show($"Ошибка приведения к типу: {ex.Message}");
                                            return;
                                        }
                                        int? ids = FindIdByType(rtable, Replece, rr);
                                        where += $" {refer.table}.id = {a} ";
                                        command.Parameters.AddWithValue(a, ids);
                                    }
                                }
                            }
                            else
                            {
                                if (column.primary_key == null) sql += $"{table.table_name}.{column.column_name} AS \"{column.lname}\"";
                                else sql += $"{table.table_name}.{column.column_name}";
                                string s = column.column_name.ToString();

                                if (columna == s)
                                {
                                    string columnType = column.type != null ? column.type.ToString() : "";
                                    object r;
                                    try
                                    {
                                        r = ReturnType(columnType, data);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Ошибка приведения к типу: {ex.Message}");
                                        return;
                                    }
                                    if (columnType == "text")
                                    {
                                        string pattern = $"%{data}%";
                                        command.Parameters.AddWithValue(a, pattern);
                                        where += $" {table.table_name}.{column.column_name} LIKE {a} ";
                                    }
                                    else
                                    {
                                        command.Parameters.AddWithValue(a, r);
                                        where += $" {table.table_name}.{column.column_name} = {a} ";
                                    }

                                }
                            }
                            if (column != lastcolum)
                            {
                                sql += ", ";
                            }

                        }
                        sql += $" FROM {table.table_name} ";

                        foreach (var column in columns)
                        {
                            if (column.references != null)
                            {
                                var refer = column.references;
                                sql += $" JOIN {refer.table} ON {refer.table}.id = {table.table_name}.{column.column_name} ";
                            }
                        }
                        sql += where;
                        sql += ";";
                        //MessageBox.Show(sql);
                    }
                }

                command.CommandText = sql;
                using (var reader = command.ExecuteReader())
                {

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    d.DataSource = dt;

                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}"); }
            finally
            {
                command.Dispose();
            }
        }
        public void QueryTool(string sql, DataGridView dataGridView)
        {
            try
            {
                using (var command = new NpgsqlCommand())
                {
                    NpgsqlConnection conn = new NpgsqlConnection(connectionString);

                    command.Connection = conn;
                    conn.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = sql;
                    using (var reader = command.ExecuteReader())
                    {
                        dataGridView.DataSource = null;

                        var dataTable = new System.Data.DataTable();
                        dataTable.Load(reader);

                        dataGridView.DataSource = dataTable;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
