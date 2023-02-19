using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class AppointmentDoctorDto
    {
        public int? Id { get; set; }
        public string Date { get; set; }

        public string Time { get; set; }

        public string PatientName { get; set; }
    }
}
