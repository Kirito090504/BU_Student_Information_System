using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInformationSheet
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void EchoPassword_Click(object sender, EventArgs e)
        {
                passwordTb.UseSystemPasswordChar = true; // Show password
                eyesclosedicon.Visible = true;
            
        }

        private void passwordTb_TextChanged(object sender, EventArgs e)
        {
            passwordTb.UseSystemPasswordChar = true;
        }

        private void eyesclosedicon_Click(object sender, EventArgs e)
        {
    
                passwordTb.UseSystemPasswordChar = false; // mask password
                eyesclosedicon.Visible = false;
                EchoPassword.Visible = true;
            

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
        }
    }
}
