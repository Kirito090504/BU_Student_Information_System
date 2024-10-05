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
    public partial class StudentSheetPage4 : Form
    {
        public StudentSheetPage4()
        {
            InitializeComponent();
        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            StudentSheetPage3 studentSheetPage3 = new StudentSheetPage3();
            studentSheetPage3.Show();
        }
    }
}
