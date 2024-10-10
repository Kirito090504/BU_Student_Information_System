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
using BaliuagU_StudentInformationSheet.Handlers;
using BaliuagU_StudentInformationSheet.Models;
using BaliuagU_StudentInformationSheet.Properties;
using BaliuagU_StudentInformationSheet.Views;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
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
            try
            {
                // Load the user's profile to the form
                if (e.RowIndex < 0)
                    return;

                string student_number = (string)dataGridView1.Rows[e.RowIndex].Cells["student_number"].Value;
                this.active_student = db_handler.QuickGetStudent(student_number);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while loading the student's information. Please try again.\n\n" + ex.Message,
                    "Error Loading Student",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
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

        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (active_student == null)
                {
                    MessageBox.Show(
                        "You need to select a student before exporting to PDF.",
                        "No Student Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                    return;
                }

                // ask the user where to store the PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Export Student Information";
                saveFileDialog.FileName = active_student.student_number + ".pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                var s = db_handler.GetStudent(active_student.student_number);

                // create the PDF
                using (var doc = new Document(new PdfDocument(new PdfWriter(saveFileDialog.FileName))))
                {
                    var title = new Paragraph("Student Information Sheet");
                    title.SetVerticalAlignment(VerticalAlignment.MIDDLE);

                    iText.Layout.Element.Image image;
                    if (s.photo != null)
                    {
                        image = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(ImageHandler.EncodeImage(s.photo)));
                        image.SetWidth(100);
                        image.SetHeight(100);
                        image.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    }
                    else
                    {
                        image = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(ImageHandler.EncodeImage(Resources.default_profile)));
                        image.SetWidth(100);
                        image.SetHeight(100);
                        image.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);
                    }

                    var sname = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    sname.SetMarginTop(5);
                    sname.AddCell($"Name: {s.name.last}, {s.name.first} {s.name.middle}");
                    sname.AddCell($"Student No.: {s.student_number}");

                    var sinfo_row1 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    sinfo_row1.AddCell($"Gender: {s.info.gender}");
                    sinfo_row1.AddCell($"Contact No.: {s.contact.contact_number}");
                    sinfo_row1.AddCell($"Email: {s.contact.email_address}");

                    var sinfo_row2 = new Table(UnitValue.CreatePercentArray(new float[] { 25, 75 })).UseAllAvailableWidth();
                    sinfo_row2.AddCell($"Birth Date: {s.info.birth_date.ToString("yyyy-MM-dd")}");
                    sinfo_row2.AddCell($"Place of Birth: {s.info.birth_address}");

                    var sinfo_row3 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    sinfo_row3.AddCell($"Nationality: {s.info.nationality}");
                    sinfo_row3.AddCell($"Citizenship: {s.info.citizenship}");
                    sinfo_row3.AddCell($"Religion: {s.info.religion}");

                    var spresent_address_row1 = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    spresent_address_row1.AddCell($"No./Street/Barangay: {s.address.present_line1}");
                    var spresent_address_row2 = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    spresent_address_row2.AddCell($"District/Town/City/Province: {s.address.present_line2}");
                    spresent_address_row2.AddCell($"ZIP Code: {s.address.present_zip_code}");

                    var spermanent_address_row1 = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    spermanent_address_row1.AddCell($"No./Street/Barangay: {s.address.permanent_line1}");
                    var spermanent_address_row2 = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    spermanent_address_row2.AddCell($"District/Town/City/Province: {s.address.permanent_line2}");
                    spermanent_address_row2.AddCell($"ZIP Code: {s.address.permanent_zip_code}");

                    var smother_row1 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    var smother_row2 = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    if (s.family.mother == null)
                    {
                        smother_row1.AddCell("Mother's Name: N/A");
                        smother_row1.AddCell("Occupation: N/A");
                        smother_row1.AddCell("Contact No.: N/A");
                        smother_row2.AddCell("Address: N/A");
                    }
                    else
                    {
                        smother_row1.AddCell($"Mother's Name: {s.family.mother.name}");
                        smother_row1.AddCell($"Occupation: {s.family.mother.occupation}");
                        smother_row1.AddCell($"Contact No.: {s.family.mother.contact_number}");
                        smother_row2.AddCell($"Address: {s.family.mother.address}");
                    }

                    var sfather_row1 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    var sfather_row2 = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    if (s.family.father == null)
                    {
                        sfather_row1.AddCell("Father's Name: N/A");
                        sfather_row1.AddCell("Occupation: N/A");
                        sfather_row1.AddCell("Contact No.: N/A");
                        sfather_row2.AddCell("Address: N/A");
                    }
                    else
                    {
                        sfather_row1.AddCell($"Father's Name: {s.family.father.name}");
                        sfather_row1.AddCell($"Occupation: {s.family.father.occupation}");
                        sfather_row1.AddCell($"Contact No.: {s.family.father.contact_number}");
                        sfather_row2.AddCell($"Address: {s.family.father.address}");
                    }

                    var sguardian_row1 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    var sguardian_row2 = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    if (s.family.guardian == null)
                    {
                        sguardian_row1.AddCell("Guardian's Name: N/A");
                        sguardian_row1.AddCell("Occupation: N/A");
                        sguardian_row1.AddCell("Contact No.: N/A");
                        sguardian_row2.AddCell("Address: N/A");
                    }
                    else
                    {
                        sguardian_row1.AddCell($"Guardian's Name: {s.family.guardian.name}");
                        sguardian_row1.AddCell($"Occupation: {s.family.guardian.occupation}");
                        sguardian_row1.AddCell($"Contact No.: {s.family.guardian.contact_number}");
                        sguardian_row2.AddCell($"Address: {s.family.guardian.address}");
                    }

                    var last_school = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    last_school.AddCell($"Last School Attended: {s.academic_history.last_school_attended}");
                    last_school.AddCell($"Year: {s.academic_history.last_school_attended_year}");
                    var secondary_school = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    secondary_school.AddCell($"Secondary School: {s.academic_history.secondary_school}");
                    secondary_school.AddCell($"Year: {s.academic_history.secondary_school_year}");

                    var awards = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    awards.AddCell($"Awards Received:\n{s.academic_history.awards_received}");
                    awards.AddCell($"Hobbies:\n{s.personality.hobbies}");
                    awards.AddCell($"Skills:\n{s.personality.skills}");

                    // add the elements to the PDF
                    doc.Add(title);
                    doc.Add(image);
                    doc.Add(sname);
                    doc.Add(sinfo_row1);
                    doc.Add(sinfo_row2);
                    doc.Add(sinfo_row3);
                    doc.Add(new Paragraph("Present Address:"));
                    doc.Add(spresent_address_row1);
                    doc.Add(spresent_address_row2);
                    doc.Add(new Paragraph("Permanent Address:"));
                    doc.Add(spermanent_address_row1);
                    doc.Add(spermanent_address_row2);
                    doc.Add(new Paragraph("Mother's Information:"));
                    doc.Add(smother_row1);
                    doc.Add(smother_row2);
                    doc.Add(new Paragraph("Father's Information:"));
                    doc.Add(sfather_row1);
                    doc.Add(sfather_row2);
                    doc.Add(new Paragraph("Guardian's Information:"));
                    doc.Add(sguardian_row1);
                    doc.Add(sguardian_row2);
                    doc.Add(last_school);
                    doc.Add(secondary_school);
                    doc.Add(awards);
                }
                if (
                    MessageBox.Show(
                        "The student information has been successfully exported to PDF. Do you want to open it?",
                        "Student Information Exported",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    ) == DialogResult.Yes
                )
                {
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while exporting student information. Please try again.\n\n" + ex.Message,
                    "Error Exporting Student Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            UpdateStudentsList();
        }
    }
}
