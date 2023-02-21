using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class ConsultationDetailsDto
    {
        public int? AppointmentId { get; set; }

        public int? ConsultationId { get; set; }

        public string Date { get; set;}

        public string FromTime { get; set; }

        public int Status { get; set; }

        public string? Diseases { get; set; }

        public string? Elaboration { get; set; }

        public string? Medication { get; set; }

        public double? Fee { get; set; }
    }
}

