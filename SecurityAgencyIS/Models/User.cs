using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Security.Cryptography;

namespace SecurityAgencyIS.Models
{
    public class User
    {
        string connectionString = "Server=localhost;Port=5432;Database=SecurityAgencyDB;User id=postgres;Password=1234;";
        public bool isLoginExists { get; set; }
        public bool isPasswordValid { get; set; }
        public void AuthenticateUser(string login, string enteredPassword)
        {
            string query = "SELECT userpassword, salt FROM Users WHERE userlogin = @userlogin";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@userlogin", login);

                conn.Open();

                // Получаем хэш и соль
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        isLoginExists = false;
                        isPasswordValid = false;
                        return; // Завершаем метод, если логин не найден
                    }

                    // Если логин найден, читаем строку
                    reader.Read();
                    isLoginExists = true;

                    string storedHash = reader["userPassword"].ToString();
                    string storedSalt = reader["salt"].ToString();

                    // Проверяем пароль
                    isPasswordValid = VerifyPassword(enteredPassword, storedHash, storedSalt);
                }
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            // Объединяем введённый пароль с солью
            string saltedPassword = enteredPassword + storedSalt;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Преобразуем хэш в строку
                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append(b.ToString("x2"));
                }

                // Сравниваем вычисленный хэш с сохранённым
                return hashStringBuilder.ToString() == storedHash;
            }
        }
    }
}
