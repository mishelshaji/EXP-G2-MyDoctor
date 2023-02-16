using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string PatientMasterId { get; set; }

        public PatientsMaster PatientsMaster { get; set; }

        public string DoctorId { get; set; }

        public DoctorMaster DoctorMaster { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int Status { get; set; }
    }
}
