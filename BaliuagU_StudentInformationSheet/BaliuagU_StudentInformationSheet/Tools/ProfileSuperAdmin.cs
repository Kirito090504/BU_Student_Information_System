using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaliuagU_StudentInformationSheet.Handlers;
using BaliuagU_StudentInformationSheet.Models;

namespace BaliuagU_StudentInformationSheet.Tools
{
    public partial class ProfileSuperAdmin : UserControl
    {
        private UserModel user;
        private bool edit_mode = false;

        public ProfileSuperAdmin()
        {
            InitializeComponent();
        }

        public void LoadProfile(UserModel user)
        {
            this.user = user;
            txtName.Text = user.full_name == null ? "" : user.full_name;
            cboRole.SelectedIndex = user.privilege == UserModel.Privilege.Admin ? 1 : 0;
            txtUsername.Text = user.username;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "(unchanged)" || string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "(unchanged)";
                txtPassword.ForeColor = Color.DimGray;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (edit_mode)
            {
                // Save changes and disable editing of fields
                try
                {
                    user.full_name = txtName.Text;
                    user.privilege =
                        cboRole.SelectedIndex == 1
                            ? UserModel.Privilege.Admin
                            : UserModel.Privilege.User;
                    user.username = txtUsername.Text;
                    if (txtPassword.Text != "(unchanged)")
                    {
                        if (UserModel.ValidatePassword(txtPassword.Text))
                            user.userpass = PasswordHandler.SHA256(txtPassword.Text);
                        else
                            throw new Exception("You have entered an invalid password!");
                    }
                    user.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Unable to Save Profile",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                saveBtn.Text = "Edit Profile";
                txtName.Enabled = false;
                // cboRole.Enabled = false;
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                edit_mode = false;
            }
            else
            {
                // Enable editing of fields
                saveBtn.Text = "Save Changes";
                txtName.Enabled = true;
                // cboRole.Enabled = true;
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                edit_mode = true;
            }
        }
    }
}
