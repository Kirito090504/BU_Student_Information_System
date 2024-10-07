using BaliuagU_StudentInformationSheet.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaliuagU_StudentInformationSheet.Views
{
    public partial class SuperAdminDashboard : Form
    {
        public SuperAdminDashboard()
        {
            InitializeComponent();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();

                LoginPage loginForm = new LoginPage();
                loginForm.Show();
            }
        }

        private void SuperAdminDashboard_Load(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            manageUsers1.Visible = false;
            profileSuperAdmin1.Visible = false;
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            manageUsers1.Visible = false;
            profileSuperAdmin1.Visible = false;
        }

        private void manageUsersBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            manageUsers1.Visible = true;
            profileSuperAdmin1.Visible = false;
        }

        private void accountSettingsBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            manageUsers1.Visible = false;
            profileSuperAdmin1.Visible = true;
        }
    }
}
