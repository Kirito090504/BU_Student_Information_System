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
        public int student_number { get; set; }
        public string name_first;
        public string name_middle;
        public string name_last;
        public Image photo;
        public int gender;
        public DateTime birth_date;
        public string birth_address;
        public int nationality;
        public int citizenship;
        public int religion;

        public void Save()
        {
            //TO DO
        }
    }
}
