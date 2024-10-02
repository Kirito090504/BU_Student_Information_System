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
        public static string SHA256(string password)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto) hash.Append(theByte.ToString("x2"));
            return hash.ToString();
        }
    }
}
