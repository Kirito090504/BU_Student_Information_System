using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentInformationSheet.Handlers;

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

                txtPassword.UseSystemPasswordChar = true; // show password
                eyesclosedicon.Visible = true;
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void eyesclosedicon_Click(object sender, EventArgs e)
        {
    
                txtPassword.UseSystemPasswordChar = false; // mask password
                eyesclosedicon.Visible = false;
                EchoPassword.Visible = true;
            

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var login_handler = new DatabaseHandler();
            var user = login_handler.Login(txtUsername.Text, txtPassword.Text);
            if (user.user_id == -1)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }
            this.Visible = false;
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Closed += (s, args) => this.Close();
            adminMenu.Show();
        }
    }
}
