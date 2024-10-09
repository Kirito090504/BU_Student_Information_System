#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models
{
    public class UserModel
    {
        public static readonly char[] allowed_username_chars = new char[] { '-', '_', '.' };
        public static readonly int PROFILE_PICTURE_MAX_SIZE = 1024 * 1024 * 2; // 2MB

        public enum Privilege
        {
            User = 1,
            Admin = 2,
        }

        public int user_id { get; }
        public string username
        {
            get { return this._username; }
            set
            {
                if (!ValidateUsername(value))
                    throw new ArgumentException("Invalid username");

                this._username = value;
            }
        }
        public string userpass { get; set; }
        public Privilege privilege { get; set; }
        public string? full_name { get; set; }

        private string _username;

        public UserModel(
            int user_id,
            string username,
            string userpass,
            Privilege privilege,
            string? full_name = null
        )
        {
            this.user_id = user_id;
            this._username = ValidateUsername(username)
                ? username
                : throw new ArgumentException("Invalid username");
            this.userpass = userpass;
            this.privilege = privilege;
            this.full_name = full_name;
        }

        public static bool ValidateUsername(string username)
        {
            return (
                username.Length > 0
                && username.All(c => char.IsLetterOrDigit(c) || allowed_username_chars.Contains(c))
            );
        }

        public static bool ValidatePassword(string password)
        {
            return password.Length >= 8;
        }

        public void Save()
        {
            using (var connection = new DatabaseHandler().GetNewConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "UPDATE users SET username = @username, userpass = @userpass, "
                        + "privilege = @privilege, full_name = @full_name WHERE user_id = @user_id";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@userpass", userpass);
                    command.Parameters.AddWithValue("@privilege", (int)privilege);
                    command.Parameters.AddWithValue("@full_name", full_name);
                    command.Parameters.AddWithValue("@user_id", user_id);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to update user.");
                }
            }
        }
    }
}
