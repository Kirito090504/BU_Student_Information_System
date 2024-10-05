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
    public partial class StudentSheetPage1 : Form
    {
        public StudentSheetPage1()
        {
            InitializeComponent();
            GenderText.Items.Add("Male");
            GenderText.Items.Add("Female");
        }

        private void uploadBtn_Click_1(object sender, EventArgs e)
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
            StudentSheetPage2 studentSheetPage2 = new StudentSheetPage2();
            studentSheetPage2.Show();
        }
    }
}
