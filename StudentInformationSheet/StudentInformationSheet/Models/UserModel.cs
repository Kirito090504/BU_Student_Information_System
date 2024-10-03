using StudentInformationSheet.Handlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSheet.Models
{
    internal class UserModel
    {
        public int user_id { get; } = -1;
        public string username {
            get { return this._username; }
            set
            {
                if (value.Length < 1)
                    throw new ArgumentException("Invalid username");

                this._username = value;
            }
        }
        public string userpass { get; set; }
        public int privilege { get; set; }
        public string? full_name { get; set; }
        public Image? photo { get; set; }

        private string _username;
        private string _userpass;

        public UserModel(
            int user_id,
            string username, 
            string userpass, 
            int privilege, 
            string? full_name = null, 
            Image? photo = null
        )
        {
            this.user_id = user_id;
            this.username = username;
            this.userpass = userpass;
            this.privilege = privilege;
            this.full_name = full_name;
            this.photo = photo;
        }
      
        public void Save()
        {
            //TO DO
        }
    }
}
