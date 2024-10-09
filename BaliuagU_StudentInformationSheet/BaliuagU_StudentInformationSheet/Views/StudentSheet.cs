using StudentInformationSheet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaliuagU_StudentInformationSheet.Views
{
    public partial class StudentSheet : Form
    {
        private DatabaseHandler db = new DatabaseHandler();
        private StudentModel? active_student = null;

        public StudentSheet()
        {
            InitializeComponent();
        }

        public void LoadStudent(StudentModel student)
        {
            this.active_student = student;

            txtStudentNo.Text = student.student_number;
            pictureBox.Image = student.photo;

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

            txtMotherName.Text = student.family.mother.name;
            txtMotherOccupation.Text = student.family.mother.occupation;
            txtMotherContactNo.Text = student.family.mother.contact_number;
            txtMotherAddress.Text = student.family.mother.address;

            txtFatherName.Text = student.family.father.name;
            txtFatherOccupation.Text = student.family.father.occupation;
            txtFatherContactNo.Text = student.family.father.contact_number;
            txtFatherAddress.Text = student.family.father.address;

            txtGuardianName.Text = student.family.guardian.name;
            txtGuardianOccupation.Text = student.family.guardian.occupation;
            txtGuardianContactNo.Text = student.family.guardian.contact_number;
            txtGuardianAddress.Text = student.family.guardian.address;

            txtLastSchool.Text = student.academic_history.last_school_attended;
            txtLastSchoolYear.Text = Convert.ToString(student.academic_history.last_school_attended_year);
            txtSecondarySchool.Text = student.academic_history.secondary_school;
            txtSecondarySchoolYear.Text = Convert.ToString(student.academic_history.secondary_school_year);

            txtHobbies.Text = student.personality.hobbies;
            txtTalent.Text = student.personality.skills;
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
