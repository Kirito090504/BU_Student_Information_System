#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaliuagU_StudentInformationSheet.Handlers;
using BaliuagU_StudentInformationSheet.Models;
using BaliuagU_StudentInformationSheet.Properties;
using BaliuagU_StudentInformationSheet.Views;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Properties.Grid;
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
                    // Get the resources of the dashboard because it is not available in Resource.
                    System.ComponentModel.ComponentResourceManager dashboard_resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
                    Style style_h1 = new Style()
                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                        .SetFontSize(14)
                        .SetFontColor(ColorConstants.BLACK)
                        .SetTextAlignment(TextAlignment.CENTER);
                    Style style_h2 = new Style()
                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLDOBLIQUE))
                        .SetFontSize(10)
                        .SetFontColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER);
                    Style style_s1 = new Style()
                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE))
                        .SetFontSize(7)
                        .SetFontColor(ColorConstants.GRAY)
                        .SetPaddingRight(5);
                    Style style_s2 = new Style()
                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                        .SetFontSize(11)
                        .SetFontColor(ColorConstants.BLACK);

                    // Header
                    var div_header = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
                    var div_header_left = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    var div_header_right = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();

                    // BU Logo
                    div_header_left.AddCell(
                        new Cell().Add(
                            new iText.Layout.Element.Image(
                                iText.IO.Image.ImageDataFactory.Create(
                                    ImageHandler.EncodeImage(
                                    (System.Drawing.Image)dashboard_resources.GetObject("panel3.BackgroundImage")
                                    )
                                )
                            )
                        ).SetBorder(Border.NO_BORDER)
                    );
                    // Document title
                    div_header_left.AddCell(
                        new Cell().Add(
                            new Paragraph("Student Information Sheet")
                                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                                .AddStyle(style_h1)
                        ).SetBorder(Border.NO_BORDER)
                    );
                    // Student Profile Picture
                    var image = s.photo != null
                        ? new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(ImageHandler.EncodeImage(s.photo)))
                        : new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(ImageHandler.EncodeImage(Resources.default_profile)));

                    div_header_right.AddCell(
                        new Cell().Add(
                            image.SetWidth(100).SetHeight(100)
                                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                        ).SetBorder(Border.NO_BORDER)
                    );

                    var div_header_left_cell = new Cell().Add(div_header_left).SetBorder(Border.NO_BORDER);
                    var div_header_right_cell = new Cell().Add(div_header_right).SetBorder(Border.NO_BORDER);

                    div_header.AddCell(div_header_left_cell);
                    div_header.AddCell(div_header_right_cell);

                    // Student Information
                    var sname = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    sname.SetMarginTop(5);
                    sname.AddCell(
                        new Paragraph()
                            .Add(new Text("Name").AddStyle(style_s1))
                            .Add(new Text($"{s.name.last}, {s.name.first} {s.name.middle}").AddStyle(style_s2)
                        )
                    );
                    sname.AddCell(
                        new Paragraph()
                            .Add(new Text("Student No.").AddStyle(style_s1))
                            .Add(new Text(s.student_number).AddStyle(style_s2)
                        )
                    );

                    var sinfo_row1 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    sinfo_row1.AddCell(
                        new Paragraph()
                            .Add(new Text("Gender").AddStyle(style_s1))
                            .Add(new Text(s.info.gender).AddStyle(style_s2)
                        )
                    );
                    sinfo_row1.AddCell(
                        new Paragraph()
                            .Add(new Text("Contact No.").AddStyle(style_s1))
                            .Add(new Text(s.contact.contact_number).AddStyle(style_s2)
                        )
                    );
                    sinfo_row1.AddCell(
                        new Paragraph()
                            .Add(new Text("Email").AddStyle(style_s1))
                            .Add(new Text(s.contact.email_address).AddStyle(style_s2)
                        )
                    );

                    var sinfo_row2 = new Table(UnitValue.CreatePercentArray(new float[] { 25, 75 })).UseAllAvailableWidth();
                    sinfo_row2.AddCell(
                        new Paragraph()
                            .Add(new Text("Birth Date").AddStyle(style_s1))
                            .Add(new Text(s.info.birth_date.ToString("MMM dd, yyyy")).AddStyle(style_s2)
                        )
                    );
                    sinfo_row2.AddCell(
                        new Paragraph()
                            .Add(new Text("Place of Birth").AddStyle(style_s1))
                            .Add(new Text(s.info.birth_address).AddStyle(style_s2)
                        )
                    );

                    var sinfo_row3 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    sinfo_row3.AddCell(
                        new Paragraph()
                            .Add(new Text("Nationality").AddStyle(style_s1))
                            .Add(new Text(s.info.nationality).AddStyle(style_s2)
                        )
                    );
                    sinfo_row3.AddCell(
                        new Paragraph()
                            .Add(new Text("Citizenship").AddStyle(style_s1))
                            .Add(new Text(s.info.citizenship).AddStyle(style_s2)
                        )
                    );
                    sinfo_row3.AddCell(
                        new Paragraph()
                            .Add(new Text("Religion").AddStyle(style_s1))
                            .Add(new Text(s.info.religion).AddStyle(style_s2)
                        )
                    );

                    var spresent_address_row1 = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    spresent_address_row1.AddCell(
                        new Paragraph()
                            .Add(new Text("No./Street/Barangay").AddStyle(style_s1))
                            .Add(new Text(s.address.present_line1).AddStyle(style_s2)
                        )
                    );
                    var spresent_address_row2 = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    spresent_address_row2.AddCell(
                        new Paragraph()
                            .Add(new Text("District/Town/City/Province").AddStyle(style_s1))
                            .Add(new Text(s.address.present_line2).AddStyle(style_s2)
                        )
                    );
                    spresent_address_row2.AddCell(
                        new Paragraph()
                            .Add(new Text("ZIP Code").AddStyle(style_s1))
                            .Add(new Text(Convert.ToString(s.address.present_zip_code)).AddStyle(style_s2)
                        )
                    );

                    var spermanent_address_row1 = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    spermanent_address_row1.AddCell(
                        new Paragraph()
                            .Add(new Text("No./Street/Barangay").AddStyle(style_s1))
                            .Add(new Text(s.address.permanent_line1).AddStyle(style_s2)
                        )
                    );
                    var spermanent_address_row2 = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    spermanent_address_row2.AddCell(
                        new Paragraph()
                            .Add(new Text("District/Town/City/Province").AddStyle(style_s1))
                            .Add(new Text(s.address.permanent_line2).AddStyle(style_s2)
                        )
                    );
                    spermanent_address_row2.AddCell(
                        new Paragraph()
                            .Add(new Text("ZIP Code").AddStyle(style_s1))
                            .Add(new Text(Convert.ToString(s.address.permanent_zip_code)).AddStyle(style_s2)
                        )
                    );

                    var smother_row1 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    var smother_row2 = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    if (s.family.mother == null)
                    {
                        smother_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Mother's Name").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                        smother_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Occupation").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                        smother_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Contact No.").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                        smother_row2.AddCell(
                            new Paragraph()
                                .Add(new Text("Address").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                    }
                    else
                    {
                        smother_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Mother's Name").AddStyle(style_s1))
                                .Add(new Text(s.family.mother.name).AddStyle(style_s2)
                            )
                        );
                        smother_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Occupation").AddStyle(style_s1))
                                .Add(new Text(s.family.mother.occupation).AddStyle(style_s2)
                            )
                        );
                        smother_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Contact No.").AddStyle(style_s1))
                                .Add(new Text(s.family.mother.contact_number).AddStyle(style_s2)
                            )
                        );
                        smother_row2.AddCell(
                            new Paragraph()
                                .Add(new Text("Address").AddStyle(style_s1))
                                .Add(new Text(s.family.mother.address).AddStyle(style_s2)
                            )
                        );
                    }

                    var sfather_row1 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    var sfather_row2 = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    if (s.family.father == null)
                    {
                        sfather_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Father's Name").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                        sfather_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Occupation").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                        sfather_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Contact No.").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                        sfather_row2.AddCell(
                            new Paragraph()
                                .Add(new Text("Address").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                    }
                    else
                    {
                        sfather_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Father's Name").AddStyle(style_s1))
                                .Add(new Text(s.family.father.name).AddStyle(style_s2)
                            )
                        );
                        sfather_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Occupation").AddStyle(style_s1))
                                .Add(new Text(s.family.father.occupation).AddStyle(style_s2)
                            )
                        );
                        sfather_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Contact No.").AddStyle(style_s1))
                                .Add(new Text(s.family.father.contact_number).AddStyle(style_s2)
                            )
                        );
                        sfather_row2.AddCell(
                            new Paragraph()
                                .Add(new Text("Address").AddStyle(style_s1))
                                .Add(new Text(s.family.father.address).AddStyle(style_s2)
                            )
                        );
                    }

                    var sguardian_row1 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    var sguardian_row2 = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    if (s.family.guardian == null)
                    {
                        sguardian_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Guardian's Name").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                        sguardian_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Occupation").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                        sguardian_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Contact No.").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                        sguardian_row2.AddCell(
                            new Paragraph()
                                .Add(new Text("Address").AddStyle(style_s1))
                                .Add(new Text("N/A").AddStyle(style_s2)
                            )
                        );
                    }
                    else
                    {
                        sguardian_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Guardian's Name").AddStyle(style_s1))
                                .Add(new Text(s.family.guardian.name).AddStyle(style_s2)
                            )
                        );
                        sguardian_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Occupation").AddStyle(style_s1))
                                .Add(new Text(s.family.guardian.occupation).AddStyle(style_s2)
                            )
                        );
                        sguardian_row1.AddCell(
                            new Paragraph()
                                .Add(new Text("Contact No.").AddStyle(style_s1))
                                .Add(new Text(s.family.guardian.contact_number).AddStyle(style_s2)
                            )
                        );
                        sguardian_row2.AddCell(
                            new Paragraph()
                                .Add(new Text("Address").AddStyle(style_s1))
                                .Add(new Text(s.family.guardian.address).AddStyle(style_s2)
                            )
                        );
                    }

                    var last_school = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    last_school.AddCell(
                        new Paragraph()
                            .Add(new Text("Last School Attended").AddStyle(style_s1))
                            .Add(new Text(s.academic_history.last_school_attended).AddStyle(style_s2)
                        )
                    );
                    last_school.AddCell(
                        new Paragraph()
                            .Add(new Text("Year").AddStyle(style_s1))
                            .Add(new Text(Convert.ToString(s.academic_history.last_school_attended_year)).AddStyle(style_s2)
                        )
                    );
                    var secondary_school = new Table(UnitValue.CreatePercentArray(new float[] { 75, 25 })).UseAllAvailableWidth();
                    secondary_school.AddCell(
                        new Paragraph()
                            .Add(new Text("Secondary School").AddStyle(style_s1))
                            .Add(new Text(s.academic_history.secondary_school).AddStyle(style_s2)
                        )
                    );
                    secondary_school.AddCell(
                        new Paragraph()
                            .Add(new Text("Year").AddStyle(style_s1))
                            .Add(new Text(Convert.ToString(s.academic_history.secondary_school_year)).AddStyle(style_s2)
                        )
                    );

                    var awards = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    awards.AddCell(
                        new Paragraph()
                            .Add(new Text("Awards Received").AddStyle(style_s1))
                            .Add(new Text(s.academic_history.awards_received).AddStyle(style_s2)
                        )
                    );
                    awards.AddCell(
                        new Paragraph()
                            .Add(new Text("Hobbies").AddStyle(style_s1))
                            .Add(new Text(s.personality.hobbies).AddStyle(style_s2)
                        )
                    );
                    awards.AddCell(
                        new Paragraph()
                            .Add(new Text("Skills").AddStyle(style_s1))
                            .Add(new Text(s.personality.skills).AddStyle(style_s2)
                        )
                    );

                    // add the elements to the PDF
                    doc.Add(div_header);

                    doc.Add(sname);
                    doc.Add(sinfo_row1);
                    doc.Add(sinfo_row2);
                    doc.Add(sinfo_row3);
                    doc.Add(new Paragraph("Present Address").AddStyle(style_h2));
                    doc.Add(spresent_address_row1);
                    doc.Add(spresent_address_row2);
                    doc.Add(new Paragraph("Permanent Address").AddStyle(style_h2));
                    doc.Add(spermanent_address_row1);
                    doc.Add(spermanent_address_row2);
                    //doc.Add(new Paragraph("Mother's Information:").AddStyle(style_h2));
                    doc.Add(smother_row1);
                    doc.Add(smother_row2);
                    //doc.Add(new Paragraph("Father's Information:").AddStyle(style_h2));
                    doc.Add(sfather_row1);
                    doc.Add(sfather_row2);
                    //doc.Add(new Paragraph("Guardian's Information:").AddStyle(style_h2));
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
