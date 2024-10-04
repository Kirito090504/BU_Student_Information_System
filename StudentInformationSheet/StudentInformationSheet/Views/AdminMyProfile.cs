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
    public partial class AdminMyProfile : Form
    {
        public AdminMyProfile()
        {
            InitializeComponent();
        }

        private void eyesclosedicon_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false; // mask password
            eyesclosedicon.Visible = false;
            EchoPassword.Visible = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void EchoPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true; // show password
            eyesclosedicon.Visible = true;
        }

        private void uploadBtn_Click(object sender, EventArgs e) => UploadProfilePicture();

        private void btn_upload_Click(object sender, EventArgs e) => UploadProfilePicture();

        private void UploadProfilePicture()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select a Photo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                photoHolder.Image = new Bitmap(openFileDialog.FileName);
            }
        }
    }
}
