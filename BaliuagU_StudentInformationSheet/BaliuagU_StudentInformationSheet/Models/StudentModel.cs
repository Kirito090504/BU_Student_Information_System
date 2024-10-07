#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaliuagU_StudentInformationSheet.Models.StudentSubModels;
using Org.BouncyCastle.Asn1.BC;

namespace StudentInformationSheet.Models
{
    internal class StudentModel
    {
        public static readonly char[] allowed_username_chars = new char[] { '-', '_', '.' };

        public int student_number { get; }
        public StudentName name { get; set; }
        public Image? photo { get; set; }

        public StudentPersonalInformation info { get; set; }
        public StudentContactInformation contact { get; set; }
        public StudentAddressInformation address { get; set; }
        public StudentFamilyInformation family { get; set; }
        public StudentAcademicHistory academic_history { get; set; }

        public StudentModel(
            int student_number,
            StudentName name,
            StudentPersonalInformation info,
            StudentContactInformation contact,
            StudentAddressInformation address,
            StudentFamilyInformation family,
            StudentAcademicHistory academic_history,
            Image? photo = null
        )
        {
            this.student_number = student_number;
            this.name = name;
            this.info = info;
            this.contact = contact;
            this.address = address;
            this.family = family;
            this.academic_history = academic_history;
            this.photo = photo;
        }

        public void Save()
        {
            //TO DO
        }
    }
}
