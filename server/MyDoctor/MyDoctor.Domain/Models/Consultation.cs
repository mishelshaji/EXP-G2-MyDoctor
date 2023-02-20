using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Domain.Models
{
    public class Consultation
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        [StringLength(100)]
        public string Disease { get; set; }

        [StringLength(80)]
        public string? Elaboration { get; set; }

        [StringLength(200)]
        public string? Medication { get; set; }
    }
}
