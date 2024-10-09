#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaliuagU_StudentInformationSheet.Models.StudentSubModels
{
    public class StudentFamilyInformation
    {
        public GuardianAngel? mother {  get; set; }
        public GuardianAngel? father { get; set; }
        public GuardianAngel? guardian { get; set; }

        public StudentFamilyInformation(GuardianAngel? mother, GuardianAngel? father, GuardianAngel? guardian)
        {
            this.mother = mother;
            this.father = father;
            this.guardian = guardian;
        }
    }
}
