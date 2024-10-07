using BaliuagU_StudentInformationSheet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaliuagU_StudentInformationSheet.Views
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void textUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void textUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Enter username";
                txtUsername.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Enter password";
                txtPassword.ForeColor = Color.DimGray;
            }
        }

        private void hidePass_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            showPass.Visible = true;
        }

        private void showPass_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            showPass.Visible = false;
            hidePass.Visible = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginAction();
        }

        private void LoginAction()
        {
            // Check if the username or password textboxes are empty.
            if (
                txtUsername.ForeColor == Color.DimGray
                    || txtPassword.ForeColor == Color.DimGray
                    || string.IsNullOrEmpty(txtUsername.Text)
                    || string.IsNullOrEmpty(txtPassword.Text)
                )
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
                notice.Visible = true;
                return;
            }
            else if (user.privilege == UserModel.Privilege.User)
            {
                var dashboard_panel = new AdminDashboard();
                dashboard_panel.Closed += (s, args) => this.Close();
                this.Visible = false;
                dashboard_panel.Show();
            }
            else if (user.privilege == UserModel.Privilege.Admin)
            {
                var dashboard_panel = new SuperAdminDashboard();
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

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Enter) LoginAction(); 
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoginAction(); 
        }
    }
}
