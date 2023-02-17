using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Domain.Models
{
    public class PatientsMaster
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [StringLength(10)]
        public string? BloodGroup { get; set; }

        public DateTime? Dob { get; set; }

        [StringLength(10)]
        public string? Gender { get; set;}

        public long? PhoneNumber { get; set; }

        [StringLength(200)]
        public string? Address { get; set;}

        public long? EmergencyContactNumber { get; set;}

        public string? Relationship { get; set;}
    }
}
