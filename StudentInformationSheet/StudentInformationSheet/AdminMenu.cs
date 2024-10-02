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

        private void addStudentBut_Click(object sender, EventArgs e)
        {
            this.Close();
            StudentSheetPage1 studentSheetPage1 = new StudentSheetPage1();
            studentSheetPage1.Show();
        }

        private void addUserBut_Click(object sender, EventArgs e)
        {
            this.Close();
            AddUserPage addUserPage = new AddUserPage();
            addUserPage.Show();
        }

        private void editUserBut_Click(object sender, EventArgs e)
        {
            this.Close();
            EditUserPage editUserPage = new EditUserPage();
            editUserPage.Show();
        }

        private void deleteUserBut_Click(object sender, EventArgs e)
        {
            this.Close();
            DeleteUserPage deleteUserPage = new DeleteUserPage();
            deleteUserPage.Show();
        }

        private void editStudentBut_Click(object sender, EventArgs e)
        {
            this.Close();
            EditStudentPage editStudentPage = new EditStudentPage();
            editStudentPage.Show();
        }

        private void adminProfileBut_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminMyProfile adminMyProfile = new AdminMyProfile();
            adminMyProfile.Show();
        }
    }
}
