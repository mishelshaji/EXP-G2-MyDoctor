using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class PrescriptionDto
    {
        public string? Diseases { get; set; } 

        public string? Elaboration { get; set; }

        public string? Medication { get; set; }
    }
}
