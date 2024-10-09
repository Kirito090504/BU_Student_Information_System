#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaliuagU_StudentInformationSheet.Models;
using BaliuagU_StudentInformationSheet.Views;
using StudentInformationSheet.Models;

namespace BaliuagU_StudentInformationSheet.Tools
{
    public partial class Dashboard : UserControl
    {
        private DatabaseHandler db_handler = new DatabaseHandler();
        private QuickStudentModel? active_student = null;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("student_number", "Student Number");
            dataGridView1.Columns.Add("name_first", "First Name");
            dataGridView1.Columns.Add("name_middle", "Middle Name");
            dataGridView1.Columns.Add("name_last", "Last Name");
            dataGridView1.Columns.Add("gender", "Gender");
            dataGridView1.Columns.Add("birth_date", "Birth ");

            UpdateStudentsList();
            textBox1.Focus();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var studentSheet = new StudentSheet();
            studentSheet.ShowDialog();
            UpdateStudentsList();
        }

        public void UpdateStudentsList(string? filter_query = null)
        {
            List<QuickStudentModel> students =
                filter_query == null
                    ? db_handler.QuickGetAllStudents()
                    : db_handler.QuickSearchStudents(filter_query);

            lblTotalRecords.Text = Convert.ToString(db_handler.GetStudentsQuantity());

            // Add the users to the DataGridView
            dataGridView1.Rows.Clear();
            foreach (var student in students)
            {
                dataGridView1.Rows.Add(
                    student.student_number,
                    student.name.first,
                    student.name.middle,
                    student.name.last,
                    student.info.gender,
                    student.info.birth_date.ToString("yyyy-MM-dd")
                );
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Load the user's profile to the form
            if (e.RowIndex < 0)
                return;

            string student_number = (string)dataGridView1.Rows[e.RowIndex].Cells["student_number"].Value;
            this.active_student = db_handler.QuickGetStudent(student_number);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (active_student == null)
            {
                MessageBox.Show(
                    "Please select a student to delete.",
                    "No Student Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }
            db_handler.DeleteStudent(active_student.student_number);

            MessageBox.Show(
                "The student has been successfully deleted.",
                "Student Deleted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            UpdateStudentsList();
            textBox1.Focus();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (active_student == null)
                {
                    MessageBox.Show(
                        "Please select a student to update.",
                        "No Student Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                    return;
                }

                var studentSheet = new StudentSheet();
                studentSheet.LoadStudent(db_handler.GetStudent(active_student.student_number));
                studentSheet.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while updating the student. Please try again.\n\n" + ex.Message,
                    "Error Updating Student",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            UpdateStudentsList();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UpdateStudentsList(textBox1.Text);
        }
    }
}
