using StudentInformationSheet.Models;
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
    public partial class AddUserPage : Form
    {
        private Form parent_form;

        public AddUserPage(Form parent_form)
        {
            this.parent_form = parent_form;
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

        private void registerBtn_Click(object sender, EventArgs e)
        {
            UserModel.Privilege user_privilege;
            switch (UserType.SelectedIndex)
            {
                case 0:
                    user_privilege = UserModel.Privilege.User;
                    break;

                case 1:
                    user_privilege = UserModel.Privilege.Admin;
                    break;

                default:
                    MessageBox.Show(
                        "Please select the user privilege level.",
                        "Invalid User Type/Privilege",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                    return;
            }

            if (!UserModel.ValidateUsername(txtUsername.Text))
            {
                MessageBox.Show(
                    "The username that you have entered is invalid. Only alphanumeric characters are allowed, including `-`, `_`, and `.`",
                    "Invalid Username",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            if (!UserModel.ValidatePassword(txtPassword.Text))
            {
                MessageBox.Show(
                    "The password that you have entered is invalid. The password must be at least 8 characters long.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            try
            {
                new DatabaseHandler().AddUser(
                    new UserModel(
                        user_id: -1,
                        username: txtUsername.Text,
                        userpass: txtPassword.Text,
                        privilege: user_privilege
                    )
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while adding the user. Please try again.\n\n" + ex.Message,
                    "Error Adding User",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            MessageBox.Show(
                "The user has been successfully added.",
                "User Added",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            this.ReturnToHome();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            this.ReturnToHome();
        }

        private void ReturnToHome()
        {
            // Do not add a close event because the parent form should
            // be shown when the child form is closed.
            this.Dispose();
            parent_form.Show();
        }
    }
}
