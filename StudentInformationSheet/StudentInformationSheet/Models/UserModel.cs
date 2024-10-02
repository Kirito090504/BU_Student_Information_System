using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StudentInformationSheet.Models
{
    internal class UserModel
    {
        public int user_id = -1;
        public string username;
        public string userpass;
        public int privilege;
        public string? full_name;
        public Image? photo;
      
        public void Save()
        {
            //TO DO
        }
    }
}
