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

        private void addStudentBut_Click(object sender, EventArgs e)
        {
            this.Close();
            StudentSheetPage1 studentSheetPage1 = new StudentSheetPage1();
            studentSheetPage1.Show();
        }

        private void editStudentBut_Click(object sender, EventArgs e)
        {
            this.Close();
            EditStudentPage editStudentPage = new EditStudentPage();
            editStudentPage.Show();
        }
    }
}
