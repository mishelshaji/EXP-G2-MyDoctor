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
        public string AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public string DiseaseId { get; set; }
        public Disease Disease { get; set; }

        [StringLength(50)]
        public string DiseaseDetails { get; set; }

        [StringLength(50)]
        public string? DiseaseSummary { get; set; }

        [StringLength(200)]
        public string Prescription { get; set; }
    }
}
