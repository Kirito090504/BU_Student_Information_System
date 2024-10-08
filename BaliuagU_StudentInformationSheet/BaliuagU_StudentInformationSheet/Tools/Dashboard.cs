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
        private StudentModel? activer_user = null;


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
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var studentSheet = new StudentSheet();
            studentSheet.ShowDialog();
        }

        public void UpdateUsersList(string? filter_query = null)
        {
            List<StudentModel> users =
                filter_query == null ? db_handler.GetStudents() : db_handler.SearchStudents(filter_query);

            // Add the users to the DataGridView
            dataGridView1.Rows.Clear();
            foreach (var user in users)
            {
                dataGridView1.Rows.Add(
                    user.user_id,
                    user.username,
                    user.privilege == Models.UserModel.Privilege.Admin ? "Super Admin" : "Admin",
                    user.full_name == null ? "N/A" : user.full_name
                );
            }
        }

    }
}
