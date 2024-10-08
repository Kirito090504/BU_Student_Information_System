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
        public LoginPage() => InitializeComponent();

        private void EchoPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true; // mask password
            eyesclosedicon.Visible = true;
            EchoPassword.Visible = false;
        }

        private void eyesclosedicon_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false; // show password
            eyesclosedicon.Visible = false;
            EchoPassword.Visible = true;
        }

        /// <summary>
        /// This method is called when the user clicks the login button,
        /// or if they press the enter key while the username or password
        /// textbox is focused.
        /// </summary>
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

            try
            {
                var login_handler = new DatabaseHandler();
                var user = login_handler.Login(txtUsername.Text, txtPassword.Text);
                if (user == null)
                {
                    notice.Visible = true;
                    return;
                }
                else if (user.privilege == UserModel.Privilege.User)
                {
                    var dashboard_panel = new UserMenuPage();
                    dashboard_panel.Closed += (s, args) => this.Close();
                    this.Hide();
                    dashboard_panel.Show();
                }
                else if (user.privilege == UserModel.Privilege.Admin)
                {
                    var dashboard_panel = new AdminMenu();
                    dashboard_panel.Closed += (s, args) => this.Close();
                    this.Hide();
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while attempting to log in. Please try again later.\n\n{ex.Message}",
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void loginBtn_Click(object sender, EventArgs e) => LoginAction();

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginAction();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginAction();
        }

        private void btn_login_Click(object sender, EventArgs e) => LoginAction();

        // Dismiss the notice
        private void notice_Click(object sender, EventArgs e) => notice.Visible = false;
    }
}
