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
    public partial class UserMenuPage : Form
    {
        public UserMenuPage()
        {
            InitializeComponent();
        }

        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            StudentSheetPage1 studentSheetPage1 = new StudentSheetPage1();
            studentSheetPage1.Show();
        }

        private void editStudentBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            EditStudentPage editStudentPage = new EditStudentPage();
            editStudentPage.Show();
        }
    }
}
