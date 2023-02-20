using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class DoctorProfileDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long? PhoneNumber { get; set; }

        public DateTime? Dob { get; set; }

        public string? Gender { get; set; }

        public string DepartmentName { get; set; }

        public string? DoctorLicenseNo { get; set; }

    }
}
