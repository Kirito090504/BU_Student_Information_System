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
using StudentInformationSheet.Models;

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

        private void eyesclosedicon_Click(object sender, EventArgs e)
        {
    
                txtPassword.UseSystemPasswordChar = false; // mask password
                eyesclosedicon.Visible = false;
                EchoPassword.Visible = true;
            

        }

        private void LoginAction()
        {
            // Check if the username or password textboxes are empty.
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show(
                    "Please enter your username and/or password. If you do not have one, please inform your system administrator.",
                    "Credentials Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            var login_handler = new DatabaseHandler();
            var user = login_handler.Login(txtUsername.Text, txtPassword.Text);
            if (user == null)
            {
                MessageBox.Show(
                    "You have entered an incorrect username or password. Please try again.",
                    "Incorrect Credentials",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }
            else if (user.privilege == UserModel.Privilege.User)
            {
                var dashboard_panel = new UserMenuPage();
                dashboard_panel.Closed += (s, args) => this.Close();
                this.Visible = false;
                dashboard_panel.Show();
            }
            else if (user.privilege == UserModel.Privilege.Admin)
            {
                var dashboard_panel = new AdminMenu();
                dashboard_panel.Closed += (s, args) => this.Close();
                this.Visible = false;
                dashboard_panel.Show();
            }
            else
            {
                MessageBox.Show(
                    "The privilege level of the user is invalid.",
                    "Incorrect User Privilege",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e) => LoginAction();

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoginAction();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoginAction();
        }
    }
}
