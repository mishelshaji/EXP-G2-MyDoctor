using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class PatientProfileDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long? PhoneNumber { get; set; }

        public DateTime? Dob { get; set; }

        public string? Gender { get; set; }

        public string? Address { get; set; }

        public string? BloodGroup { get; set; }

        public long? EmergencyContactNumber { get; set; }

        public string? Relationship { get; set; }

        public string? Email { get; set; }

    }
}
