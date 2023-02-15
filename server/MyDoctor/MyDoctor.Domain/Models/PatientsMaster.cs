using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Domain.Models
{
    public class PatientsMaster: DbContext
    {
        public ApplicationUser UserId { get; set; }

        [StringLength(10)]
        public string BloodGroup { get; set; }

        public DateOnly Dob { get; set; }

        [StringLength(5)]
        public string Gender { get; set;}

        [StringLength(200)]
        public string Address { get; set;}

        public int EmergencyContactNumber { get; set;}

        public string Relationship { get; set;}

    }
}
