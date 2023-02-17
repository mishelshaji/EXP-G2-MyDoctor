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

        public int PatientMasterId { get; set; }

        public PatientsMaster PatientsMaster { get; set; }

        public int DoctorId { get; set; }

        public DoctorMaster DoctorMaster { get; set; }

        public DateTime FromDateTime { get; set; }

        public DateTime ToDateTime { get; set; }

        public int Status { get; set; }
    }
}
