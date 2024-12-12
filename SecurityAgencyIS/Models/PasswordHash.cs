using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SecurityAgencyIS.Models
{
    public class PasswordHash
    {
        public (string hashedPassword, string salt) HashPasswordWithSalt(string password)
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            
            string salt = Convert.ToBase64String(saltBytes);

            string saltedPassword = password + salt;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append(b.ToString("x2"));
                }

                return (hashStringBuilder.ToString(), salt);
            }
        }
    }
}
