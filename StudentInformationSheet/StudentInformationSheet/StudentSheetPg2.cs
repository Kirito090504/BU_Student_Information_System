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
    public partial class StudentSheetPg2 : Form
    {
        public StudentSheetPg2()
        {
            InitializeComponent();
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            StudentSheetPg1 studentSheetPg1 = new StudentSheetPg1();
            studentSheetPg1.ShowDialog();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSheetPg3 studentSheetPg3 = new StudentSheetPg3();
            studentSheetPg3.ShowDialog();
            this.Close();
        }
    }
}
