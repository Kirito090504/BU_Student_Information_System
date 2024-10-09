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
using BaliuagU_StudentInformationSheet.Views;
using StudentInformationSheet.Models;

namespace BaliuagU_StudentInformationSheet.Tools
{
    public partial class Dashboard : UserControl
    {
        private DatabaseHandler db_handler = new DatabaseHandler();

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
        }

        public void UpdateStudentsList(string? filter_query = null)
        {
            List<StudentModel> students =
                filter_query == null
                    ? db_handler.GetAllStudents()
                    : db_handler.SearchStudents(filter_query);

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
    }
}
