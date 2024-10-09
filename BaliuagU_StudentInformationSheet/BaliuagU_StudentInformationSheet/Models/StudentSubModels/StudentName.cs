#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models.StudentSubModels
{
    public class StudentName
    {
        public string first {  get; set; }
        public string? middle { get; set; }
        public string last { get; set; }

        public StudentName(string first, string? middle, string last)
        {
            this.first = first;
            this.middle = middle;
            this.last = last;
        }
    }
}
