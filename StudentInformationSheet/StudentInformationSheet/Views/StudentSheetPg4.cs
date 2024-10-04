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
    public partial class StudentSheetPg4 : Form
    {
        public StudentSheetPg4()
        {
            InitializeComponent();
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSheetPg3 studentSheetPg3 = new StudentSheetPg3();
            studentSheetPg3.ShowDialog();
            this.Close();
        }
    }
}
