using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class PrescriptionDto
    {
        public int Disease { get; set; } = 0;

        public string Elaboration { get; set; } = string.Empty;

        public string Medication { get; set; } = string.Empty;
    }
}
