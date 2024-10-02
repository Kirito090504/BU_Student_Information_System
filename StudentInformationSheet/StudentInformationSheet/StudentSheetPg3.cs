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
    public partial class StudentSheetPg3 : Form
    {
        public StudentSheetPg3()
        {
            InitializeComponent();
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSheetPg2 studentSheetPg2 = new StudentSheetPg2();
            studentSheetPg2.ShowDialog();
            this.Close();

        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSheetPg4 studentSheetPg4 = new StudentSheetPg4();
            studentSheetPg4.ShowDialog();
            this.Close();
        }
    }
}
