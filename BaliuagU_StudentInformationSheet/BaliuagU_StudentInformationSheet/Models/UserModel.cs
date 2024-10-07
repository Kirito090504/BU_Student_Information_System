#nullable enable
using BaliuagU_StudentInformationSheet.Handlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models
{
    internal class UserModel
    {
        public static readonly char[] allowed_username_chars = new char[] { '-', '_', '.' };
        public enum Privilege
        {
            User = 1,
            Admin = 2
        }

        public int user_id { get; }
        public string username
        {
            get { return this._username; }
            set
            {
                if (ValidateUsername(value))
                    throw new ArgumentException("Invalid username");

                this._username = value;
            }
        }
        public string userpass { get; set; }
        public Privilege privilege { get; set; }
        public string? full_name { get; set; }
        public Image? photo { get; set; }

        private string _username;

        public UserModel(
            int user_id,
            string username,
            string userpass,
            Privilege privilege,
            string? full_name = null,
            Image? photo = null
        )
        {
            this.user_id = user_id;
            this._username = ValidateUsername(username) ? username : throw new ArgumentException("Invalid username");
            this.userpass = userpass;
            this.privilege = privilege;
            this.full_name = full_name;
            this.photo = photo;
        }

        public static bool ValidateUsername(string username)
        {
            return !(
                username.Length < 1 || !username.All(
                    (char c) => {
                        return char.IsLetterOrDigit(c) || allowed_username_chars.Contains(c);
                    }
                )
            );
        }

        public static bool ValidatePassword(string password)
        {
            return password.Length >= 8;
        }

        public void Save()
        {
            //TO DO
        }
    }
}
