using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class AppointmentDoctorDto
    {
        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string PatientName { get; set; }
    }
}
