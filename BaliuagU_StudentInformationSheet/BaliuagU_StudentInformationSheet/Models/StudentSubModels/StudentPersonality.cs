#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models.StudentSubModels
{
    public class StudentPersonality
    {
        public string? hobbies { get; set; }
        public string? skills { get; set; }

        public StudentPersonality(string? hobbies, string? skills)
        {
            this.hobbies = hobbies;
            this.skills = skills;
        }
    }
}
