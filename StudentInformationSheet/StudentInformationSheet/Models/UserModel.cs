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
        public string username { get; }
        public string userpass { get; }
        public int privilege { get; }
        public string? full_name { get; }
        public Image? photo { get; }

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
