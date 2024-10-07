using BaliuagU_StudentInformationSheet.Handlers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaliuagU_StudentInformationSheet.Tools
{
    public partial class ManageUsers : UserControl
    {
 
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }
    }
}
