using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Security.Cryptography;

namespace SecurityAgencyIS.Models
{
    public class DBManage
    {
        public string connectionString = "Server=localhost;Port=5432;Database=SecurityAgencyDB;User id=postgres;Password=1234;";

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
    }
}
