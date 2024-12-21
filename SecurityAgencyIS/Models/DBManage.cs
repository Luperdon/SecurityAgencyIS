using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Security.Cryptography;
using System.Net.Http.Json;
using Newtonsoft.Json;

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

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
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
    }
}
