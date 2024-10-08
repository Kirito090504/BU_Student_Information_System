using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentInformationSheet.Models;

namespace StudentInformationSheet
{
    public partial class AddUserAccPage : Form
    {
        private Form parent_form; // Holds the parent form that will be shown when this form is closed.
        private bool photo_changed = false;

        public AddUserAccPage(Form parent_form)
        {
            this.parent_form = parent_form;
            InitializeComponent();
        }

        private void EchoPassword_Click(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = true; // mask password
            eyesclosedicon.Visible = true;
            EchoPassword.Visible = false;
        }

        private void eyesclosedicon_Click(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = false; // show password
            eyesclosedicon.Visible = false;
            EchoPassword.Visible = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e) => ReturnToHome();

        private void btn_register_Click(object sender, EventArgs e) => AddUser();

        private void btn_upload_Click(object sender, EventArgs e) => UploadProfilePicture();

        private void ReturnToHome()
        {
            // Do not use the `Close()` method because it will
            // call the close events, making the parent form inaccessible.
            this.Dispose();
            parent_form.Show();
        }

        /// <summary>
        /// Show a file dialog to allow the user to select a profile picture.
        /// </summary>
        private void UploadProfilePicture()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select a Photo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (
                    new System.IO.FileInfo(openFileDialog.FileName).Length
                    > UserModel.PROFILE_PICTURE_MAX_SIZE
                )
                {
                    MessageBox.Show(
                        string.Format(
                            "{0} {1} {2}",
                            "The file you have selected is too large.",
                            "Please select a file that is less than",
                            $"{UserModel.PROFILE_PICTURE_MAX_SIZE / 1024 / 1024}MB in size."
                        ),
                        "File Too Large",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                    return;
                }
                try
                {
                    photoHolder.Image = new Bitmap(openFileDialog.FileName);
                    photo_changed = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"An error occurred while loading the image. Please try again.\n\n{ex.Message}",
                        "Error Loading Image",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void AddUser()
        {
            UserModel.Privilege user_privilege;
            string user_full_name = txt_full_name.Text;

            switch (user_type.SelectedIndex)
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

            if (string.IsNullOrWhiteSpace(user_full_name))
            {
                MessageBox.Show(
                    "Please enter the full name of the new user.",
                    "Missing Full Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            if (!UserModel.ValidateUsername(txt_username.Text))
            {
                MessageBox.Show(
                    "The username that you have entered is invalid. Only alphanumeric characters are allowed, including `-`, `_`, and `.`",
                    "Invalid Username",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            if (!UserModel.ValidatePassword(txt_password.Text))
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
                        user_id: -1, // this is ignored by the database handler anyway.
                        username: txt_username.Text,
                        userpass: txt_password.Text,
                        privilege: user_privilege,
                        full_name: user_full_name,
                        photo: this.photo_changed ? photoHolder.Image : null
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
    }
}
