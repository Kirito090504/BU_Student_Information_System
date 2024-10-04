#nullable enable
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSheet.Models
{
    internal class StudentModel
    {
        public static readonly char[] allowed_username_chars = new char[] { '-', '_', '.' };
        public int student_number { get; }            
        public string name_first { get; set; }
        public string name_middle { get; set; }
        public string name_last { get; set; }
        public Image? photo { get; set; }
        public int gender;
        public DateTime birth_date;
        public string birth_address;
        public int nationality;
        public int citizenship;
        public int religion;

        public StudentModel(
            int student_number,
            string name_first,
            string name_middle,
            string name_last,
            DateTime birth_date,
            string birth_address,
            int nationality,
            int citizenship,
            int religion,
            Image? photo = null
        )
        {
            this.student_number = student_number;
            this.name_first = name_first;
            this.name_middle = name_middle; 
            this.name_last = name_last;
            this.photo = photo;
            this.birth_date = birth_date;   
            this.birth_address = birth_address;
            this.nationality = nationality;
            this.citizenship = citizenship;
            this.religion = religion;
        }
       

        public void Save()
        {
            //TO DO
        }
    }
}
