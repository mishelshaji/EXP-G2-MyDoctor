using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class PatientAppointmentsDto
    {
        public int AppointmentId { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int? DoctorId { get; set; }

        public string? DoctorName { get; set; }

        public int? PatientId { get; set; }

        public string? PatientName { get; set; }

        public int status { get; set; }
    }
}
