using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSheet
{
    internal class UserModel
    {
        public int user_id { get; set; }
        public string username;
        public string userpass;
        public int privilege;
        public string full_name;
        public string photo;

        public void Save()
        {
            //TO DO
        }
    }
}
