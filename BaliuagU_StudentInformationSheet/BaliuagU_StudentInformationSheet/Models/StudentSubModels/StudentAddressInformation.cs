#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models.StudentSubModels
{
    internal class StudentAddressInformation
    {
        public string? present_line1;
        public string present_line2;
        public int present_zip_code;
        public string? permanent_line1;
        public string permanent_line2;
        public int permanent_zip_code;

        public StudentAddressInformation(string? present_line1, string present_line2, int present_zip_code, string? permanent_line1, string permanent_line2, int permanent_zip_code)
        {
            this.present_line1 = present_line1;
            this.present_line2 = present_line2;
            this.present_zip_code = present_zip_code;
            this.permanent_line1 = permanent_line1;
            this.permanent_line2 = permanent_line2;
            this.permanent_zip_code = permanent_zip_code;
        }
    }
}
