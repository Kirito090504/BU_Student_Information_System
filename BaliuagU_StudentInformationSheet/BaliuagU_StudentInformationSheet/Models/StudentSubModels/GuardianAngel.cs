#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models.StudentSubModels
{
    public class GuardianAngel
    {
        public string? name;
        public string? occupation;
        public string? contact_number;
        public string? address;

        public GuardianAngel(string? name, string? occupation, string? contact_number, string? address)
        {
            this.name = name;
            this.occupation = occupation;
            this.contact_number = contact_number;
            this.address = address;
        }
    }
}
