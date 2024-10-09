using BaliuagU_StudentInformationSheet.Models.StudentSubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models
{
    internal class QuickStudentModel
    {
        public string student_number { get; }
        public StudentName name { get; set; }
        public StudentPersonalInformation info { get; set; }

        public QuickStudentModel(string student_number, StudentName name, StudentPersonalInformation info)
        {
            this.student_number = student_number;
            this.name = name;
            this.info = info;
        }
    }
}
