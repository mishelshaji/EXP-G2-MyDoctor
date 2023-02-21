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

        public int? PatientsMasterId { get; set; }

        public PatientsMaster? PatientsMaster { get; set; }

        public int? DoctorMasterId { get; set; }

        public DoctorMaster? DoctorMaster { get; set; }

        public string Date { get; set; }

        public string FromTime { get; set; }

        public string ToTime { get; set; }

        public int Status { get; set; }

        public double? Fee { get; set; }
    }
}
