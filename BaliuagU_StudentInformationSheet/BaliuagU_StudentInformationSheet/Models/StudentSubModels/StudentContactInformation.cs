#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models.StudentSubModels
{
    internal class StudentContactInformation
    {
        public string? contact_number;
        public string? email_address;

        public StudentContactInformation(string? contact_number, string? email_address)
        {
            this.contact_number = contact_number;
            this.email_address = email_address;
        }
    }
}
