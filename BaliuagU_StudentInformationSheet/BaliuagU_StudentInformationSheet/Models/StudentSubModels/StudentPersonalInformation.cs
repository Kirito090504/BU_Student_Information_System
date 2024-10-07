#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models.StudentSubModels
{
    internal class StudentPersonalInformation
    {
        public int gender;

        public DateTime birth_date;
        public string? birth_address;

        public string nationality;
        public string citizenship;
        public string? religion;

        public StudentPersonalInformation(
            int gender,
            DateTime birth_date,
            string? birth_address,
            string nationality,
            string citizenship,
            string? religion
        )
        {
            this.gender = gender;
            this.birth_date = birth_date;
            this.birth_address = birth_address;
            this.nationality = nationality;
            this.citizenship = citizenship;
            this.religion = religion;
        }
    }
}
