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
    public partial class StudentSheetPg1 : Form
    {
        public StudentSheetPg1()
        {
            InitializeComponent();
            cboGender.Items.Add("Male");
            cboGender.Items.Add("Female");
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select a Photo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                photoHolder.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSheetPg2 studentSheetPg2 = new StudentSheetPg2();
            studentSheetPg2.ShowDialog();
            this.Close();
        }
    }
}
