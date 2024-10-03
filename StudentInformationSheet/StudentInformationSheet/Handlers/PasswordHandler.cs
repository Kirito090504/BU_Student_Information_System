using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSheet.Handlers
{
    internal class PasswordHandler
    {
        /// <summary>
        /// Return a SHA-256 hashed version of the password.
        /// </summary>
        /// <param name="password">The plaintext version of the password.</param>
        /// <returns>A SHA-256 hashed version of the password.</returns>
        public static string SHA256(string password)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] encoded_pw = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte b in encoded_pw) hash.Append(b.ToString("x2"));
            return hash.ToString();
        }
    }
}
