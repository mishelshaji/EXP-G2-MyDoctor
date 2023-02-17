using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    internal class DoctorAppointmentDto
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string PatientName { get; set; }

        public DateTime DateTime { get; set; }
    }
}
