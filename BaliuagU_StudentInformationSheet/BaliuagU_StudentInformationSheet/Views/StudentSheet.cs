#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaliuagU_StudentInformationSheet.Handlers;
using BaliuagU_StudentInformationSheet.Models;
using BaliuagU_StudentInformationSheet.Models.StudentSubModels;
using BaliuagU_StudentInformationSheet.Properties;
using StudentInformationSheet.Models;

namespace BaliuagU_StudentInformationSheet.Views
{
    public partial class StudentSheet : Form
    {
        private DatabaseHandler db = new DatabaseHandler();
        private StudentModel? active_student = null;
        private bool photo_changed = false;

        public StudentSheet()
        {
            InitializeComponent();
        }

        public void LoadStudent(StudentModel student)
        {
            this.active_student = student;
            this.photo_changed = false;

            txtStudentNo.Text = student.student_number;
            pictureBox.Image = new Bitmap(
                student.photo == null ? Resources.default_profile : student.photo
            );

            txtFirstname.Text = student.name.first;
            txtMiddleName.Text = student.name.middle;
            txtLastname.Text = student.name.last;

            cboGender.SelectedIndex = student.info.gender == "Male" ? 0 : 1;
            txtContactNo.Text = student.contact.contact_number;
            txtEmail.Text = student.contact.email_address;
            birthdateTimePicker.Value = student.info.birth_date;
            txtBirthplace.Text = student.info.birth_address;

            txtPresentStreet.Text = student.address.present_line1;
            txtPresentCity.Text = student.address.present_line2;
            txtPresentZipcode.Text = Convert.ToString(student.address.present_zip_code);

            txtPermanentStreet.Text = student.address.permanent_line1;
            txtPermanentCity.Text = student.address.permanent_line2;
            txtPermanentZipcode.Text = Convert.ToString(student.address.permanent_zip_code);

            txtMotherName.Text = student.family.mother == null ? "" : student.family.mother.name;
            txtMotherOccupation.Text =
                student.family.mother == null ? "" : student.family.mother.occupation;
            txtMotherContactNo.Text =
                student.family.mother == null ? "" : student.family.mother.contact_number;
            txtMotherAddress.Text =
                student.family.mother == null ? "" : student.family.mother.address;

            txtFatherName.Text = student.family.father == null ? "" : student.family.father.name;
            txtFatherOccupation.Text =
                student.family.father == null ? "" : student.family.father.occupation;
            txtFatherContactNo.Text =
                student.family.father == null ? "" : student.family.father.contact_number;
            txtFatherAddress.Text =
                student.family.father == null ? "" : student.family.father.address;

            txtGuardianName.Text =
                student.family.guardian == null ? "" : student.family.guardian.name;
            txtGuardianOccupation.Text =
                student.family.guardian == null ? "" : student.family.guardian.occupation;
            txtGuardianContactNo.Text =
                student.family.guardian == null ? "" : student.family.guardian.contact_number;
            txtGuardianAddress.Text =
                student.family.guardian == null ? "" : student.family.guardian.address;

            txtLastSchool.Text = student.academic_history.last_school_attended;
            txtLastSchoolYear.Text = Convert.ToString(
                student.academic_history.last_school_attended_year
            );
            txtSecondarySchool.Text = student.academic_history.secondary_school;
            txtSecondarySchoolYear.Text = Convert.ToString(
                student.academic_history.secondary_school_year
            );

            txtHobbies.Text = student.personality.hobbies;
            txtTalent.Text = student.personality.skills;
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select a Photo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (
                    new System.IO.FileInfo(openFileDialog.FileName).Length
                    > UserModel.PROFILE_PICTURE_MAX_SIZE
                )
                {
                    MessageBox.Show(
                        string.Format(
                            "{0} {1} {2}",
                            "The file you have selected is too large.",
                            "Please select a file that is less than",
                            $"{UserModel.PROFILE_PICTURE_MAX_SIZE / 1024 / 1024}MB in size."
                        ),
                        "File Too Large",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                    return;
                }
                try
                {
                    pictureBox.Image = new Bitmap(openFileDialog.FileName);
                    photo_changed = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"An error occurred while loading the image. Please try again.\n\n{ex.Message}",
                        "Error Loading Image",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (active_student == null)
                {
                    active_student = new StudentModel(
                        student_number: txtStudentNo.Text,
                        name: new StudentName(
                            first: txtFirstname.Text,
                            middle: txtMiddleName.Text,
                            last: txtLastname.Text
                        ),
                        photo: photo_changed ? pictureBox.Image : null,
                        info: new StudentPersonalInformation(
                            gender: cboGender.SelectedItem.ToString(),
                            birth_date: birthdateTimePicker.Value,
                            birth_address: txtBirthplace.Text,
                            nationality: "Filipino", // FIXME
                            citizenship: "Filipino", // FIXME
                            religion: "Roman Catholic" // FIXME
                        ),
                        contact: new StudentContactInformation(
                            contact_number: txtContactNo.Text,
                            email_address: txtEmail.Text
                        ),
                        address: new StudentAddressInformation(
                            present_line1: txtPresentStreet.Text,
                            present_line2: txtPresentCity.Text,
                            present_zip_code: Convert.ToInt32(txtPresentZipcode.Text),
                            permanent_line1: txtPermanentStreet.Text,
                            permanent_line2: txtPermanentCity.Text,
                            permanent_zip_code: Convert.ToInt32(txtPermanentZipcode.Text)
                        ),
                        family: new StudentFamilyInformation(
                            mother: new GuardianAngel(
                                name: txtMotherName.Text,
                                occupation: txtMotherOccupation.Text,
                                contact_number: txtMotherContactNo.Text,
                                address: txtMotherAddress.Text
                            ),
                            father: new GuardianAngel(
                                name: txtFatherName.Text,
                                occupation: txtFatherOccupation.Text,
                                contact_number: txtFatherContactNo.Text,
                                address: txtFatherAddress.Text
                            ),
                            guardian: new GuardianAngel(
                                name: txtGuardianName.Text,
                                occupation: txtGuardianOccupation.Text,
                                contact_number: txtGuardianContactNo.Text,
                                address: txtGuardianAddress.Text
                            )
                        ),
                        academic_history: new StudentAcademicHistory(
                            last_school_attended: txtLastSchool.Text,
                            last_school_attended_year: Convert.ToInt32(txtLastSchoolYear.Text),
                            secondary_school: txtSecondarySchool.Text,
                            secondary_school_year: Convert.ToInt32(txtSecondarySchoolYear.Text),
                            awards_received: null // FIXME
                        ),
                        personality: new StudentPersonality(
                            hobbies: txtHobbies.Text,
                            skills: txtTalent.Text
                        )
                    );

                    db.AddStudent(active_student);
                }
                else
                {
                    active_student.photo = photo_changed ? pictureBox.Image : active_student.photo;

                    active_student.name.first = txtFirstname.Text;
                    active_student.name.middle = txtMiddleName.Text;
                    active_student.name.last = txtLastname.Text;

                    active_student.info.gender = cboGender.SelectedIndex == 0 ? "Male" : "Female";

                    active_student.contact.contact_number = txtContactNo.Text;
                    active_student.contact.email_address = txtEmail.Text;

                    active_student.info.birth_date = birthdateTimePicker.Value;
                    active_student.info.birth_address = txtBirthplace.Text;

                    active_student.address.present_line1 = txtPresentStreet.Text;
                    active_student.address.present_line2 = txtPresentCity.Text;
                    active_student.address.present_zip_code = Convert.ToInt32(
                        txtPresentZipcode.Text
                    );

                    active_student.address.permanent_line1 = txtPermanentStreet.Text;
                    active_student.address.permanent_line2 = txtPermanentCity.Text;
                    active_student.address.permanent_zip_code = Convert.ToInt32(
                        txtPermanentZipcode.Text
                    );

                    if (
                        !string.IsNullOrEmpty(txtMotherName.Text)
                        || !string.IsNullOrEmpty(txtMotherOccupation.Text)
                        || !string.IsNullOrEmpty(txtMotherContactNo.Text)
                        || !string.IsNullOrEmpty(txtMotherAddress.Text)
                    )
                    {
                        if (active_student.family.mother == null)
                            active_student.family.mother = new GuardianAngel(
                                name: txtMotherName.Text,
                                occupation: txtMotherOccupation.Text,
                                contact_number: txtMotherContactNo.Text,
                                address: txtMotherAddress.Text
                            );
                    }

                    if (
                        !string.IsNullOrEmpty(txtFatherName.Text)
                        || !string.IsNullOrEmpty(txtFatherOccupation.Text)
                        || !string.IsNullOrEmpty(txtFatherContactNo.Text)
                        || !string.IsNullOrEmpty(txtFatherAddress.Text)
                    )
                    {
                        if (active_student.family.father == null)
                            active_student.family.father = new GuardianAngel(
                                name: txtFatherName.Text,
                                occupation: txtFatherOccupation.Text,
                                contact_number: txtFatherContactNo.Text,
                                address: txtFatherAddress.Text
                            );
                    }

                    if (
                        !string.IsNullOrEmpty(txtGuardianName.Text)
                        || !string.IsNullOrEmpty(txtGuardianOccupation.Text)
                        || !string.IsNullOrEmpty(txtGuardianContactNo.Text)
                        || !string.IsNullOrEmpty(txtGuardianAddress.Text)
                    )
                    {
                        if (active_student.family.guardian == null)
                            active_student.family.guardian = new GuardianAngel(
                                name: txtGuardianName.Text,
                                occupation: txtGuardianOccupation.Text,
                                contact_number: txtGuardianContactNo.Text,
                                address: txtGuardianAddress.Text
                            );
                    }

                    active_student.academic_history.last_school_attended = txtLastSchool.Text;
                    active_student.academic_history.last_school_attended_year = Convert.ToInt32(
                        txtLastSchoolYear.Text
                    );
                    active_student.academic_history.secondary_school = txtSecondarySchool.Text;
                    active_student.academic_history.secondary_school_year = Convert.ToInt32(
                        txtSecondarySchoolYear.Text
                    );

                    active_student.personality.hobbies = txtHobbies.Text;
                    active_student.personality.skills = txtTalent.Text;

                    active_student.Save();
                }
                MessageBox.Show(
                    "Student information saved successfully.",
                    "Student Information Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while saving the student information. Please try again.\n\n{ex.Message}",
                    "Error Saving Student Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (active_student != null)
                LoadStudent(active_student);
            else
            {
                txtStudentNo.Text = "";
                pictureBox.Image = Resources.default_profile;

                txtFirstname.Text = "";
                txtMiddleName.Text = "";
                txtLastname.Text = "";

                cboGender.SelectedIndex = -1;
                txtContactNo.Text = "";
                txtEmail.Text = "";
                birthdateTimePicker.Value = DateTime.Now;
                txtBirthplace.Text = "";

                txtPresentStreet.Text = "";
                txtPresentCity.Text = "";
                txtPresentZipcode.Text = "";

                txtPermanentStreet.Text = "";
                txtPermanentCity.Text = "";
                txtPermanentZipcode.Text = "";

                txtMotherName.Text = "";
                txtMotherOccupation.Text = "";
                txtMotherContactNo.Text = "";
                txtMotherAddress.Text = "";

                txtFatherName.Text = "";
                txtFatherOccupation.Text = "";
                txtFatherContactNo.Text = "";
                txtFatherAddress.Text = "";

                txtGuardianName.Text = "";
                txtGuardianOccupation.Text = "";
                txtGuardianContactNo.Text = "";
                txtGuardianAddress.Text = "";

                txtLastSchool.Text = "";
                txtLastSchoolYear.Text = "";
                txtSecondarySchool.Text = "";
                txtSecondarySchoolYear.Text = "";

                txtHobbies.Text = "";
                txtTalent.Text = "";
            }
        }
    }
}
