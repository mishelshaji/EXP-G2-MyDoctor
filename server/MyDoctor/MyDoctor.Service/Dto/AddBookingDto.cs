using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class AddBookingDto
    {
        public int PatientMasterId { get; set; }

        public int DoctorMasterId { get; set;}

        public string Date { get; set; }

        public string FromTime { get; set; }

        public string ToTime { get; set; }

        public int Status { get; set; } 

    }
}
