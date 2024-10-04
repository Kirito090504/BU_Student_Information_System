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
            this.Hide();
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
            
            EditUserProfilePage editUserProfilePage = new EditUserProfilePage();
            this.Hide();
            editUserProfilePage.ShowDialog();
            this.Show();
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            
            DeleteUserProfilePage deleteUserProfilePage = new DeleteUserProfilePage();
            this.Hide();
            deleteUserProfilePage.ShowDialog();
            this.Show();
        }

        private void editStudentBtn_Click(object sender, EventArgs e)
        {
            
            EditStudentPage editStudentPage = new EditStudentPage();
            this.Hide();
            editStudentPage.ShowDialog();
            this.Show();
        }

        private void adminProfileBtn_Click(object sender, EventArgs e)
        {
            
            AdminMyProfile adminMyProfile = new AdminMyProfile();
            this.Hide();
            adminMyProfile.ShowDialog();
            this.Show();
        }
    }
}
