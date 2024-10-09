using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaliuagU_StudentInformationSheet.Models;
using BaliuagU_StudentInformationSheet.Tools;

namespace BaliuagU_StudentInformationSheet.Views
{
    public partial class SuperAdminDashboard : Form
    {
        private UserModel user;

        public SuperAdminDashboard(UserModel user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var login_form = new LoginPage();
                login_form.Closed += (s, args) => this.Close();
                this.Visible = false;
                login_form.Show();
            }
        }

        private void SuperAdminDashboard_Load(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            manageUsers1.Visible = false;
            profileSuperAdmin1.Visible = false;

            lblName.Text = user.username;
            manageUsers1.SetCurrentUser(user);
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            manageUsers1.Visible = false;
            profileSuperAdmin1.Visible = false;
            dashboard1.UpdateStudentsList();
        }

        private void manageUsersBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            manageUsers1.Visible = true;
            profileSuperAdmin1.Visible = false;
            manageUsers1.UpdateUsersList();
            lblName.Text = user.username;
        }

        private void accountSettingsBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            manageUsers1.Visible = false;
            profileSuperAdmin1.Visible = true;
            profileSuperAdmin1.LoadProfile(user); // load user profile to the user control
        }
    }
}
