using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using InterfacesLL;

namespace LogicLayer
{
    public class PasswordHashingLL : _PasswordHashingLL
    {
        public PasswordHashingLL()
        {
        }

        public string PassSalt(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+";

            StringBuilder password = new StringBuilder();

            Random random = new Random();

            while (0 < length--)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            return password.ToString();
        }

        public string PassHash(string password, string salt)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);

            byte[] saltedInputBytes = new byte[saltBytes.Length + inputBytes.Length];
            Buffer.BlockCopy(saltBytes, 0, saltedInputBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(inputBytes, 0, saltedInputBytes, saltBytes.Length, inputBytes.Length);

            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(saltedInputBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
