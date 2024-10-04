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
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            StudentSheetPage1 studentSheetPage1 = new StudentSheetPage1();
            studentSheetPage1.Show();
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            var addUserPage = new AddUserAccPage(this);
            addUserPage.Closed += (s, args) => this.Close();
            this.Visible = false;
            addUserPage.Show();
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            EditUserProfilePage editUserPage = new EditUserProfilePage();
            editUserPage.Show();
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            DeleteUserProfilePage deleteUserPage = new DeleteUserProfilePage();
            deleteUserPage.Show();
        }

        private void editStudentBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            EditStudentPage editStudentPage = new EditStudentPage();
            editStudentPage.Show();
        }

        private void adminProfileBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminMyProfile adminMyProfile = new AdminMyProfile();
            adminMyProfile.Show();
        }
    }
}
