﻿using System;
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
    public partial class UserMyProfile : Form
    {
        public UserMyProfile()
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

        private void editBtn_Click(object sender, EventArgs e)
        {
            lblPassword.Visible = true;
            txtPassword.Visible = true;
            passwordLine.Visible = true;
            eyesclosedicon.Visible = true;
        }
    }
}
