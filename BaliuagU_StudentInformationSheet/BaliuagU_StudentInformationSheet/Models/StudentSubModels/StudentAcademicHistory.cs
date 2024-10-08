#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models.StudentSubModels
{
    internal class StudentAcademicHistory
    {
        public string? last_school_attended;
        public int? last_school_attended_year;

        public string? secondary_school;
        public int? secondary_school_year;

        public string? awards_received;

        public StudentAcademicHistory(
            string? last_school_attended,
            int? last_school_attended_year,
            string? secondary_school,
            int? secondary_school_year,
            string? awards_received
        )
        {
            this.last_school_attended = last_school_attended;
            this.last_school_attended_year = last_school_attended_year;
            this.secondary_school = secondary_school;
            this.secondary_school_year = secondary_school_year;
            this.awards_received = awards_received;
        }
    }
}
