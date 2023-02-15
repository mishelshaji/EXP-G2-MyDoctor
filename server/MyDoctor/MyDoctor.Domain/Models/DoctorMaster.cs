using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Domain.Models
{
    public class DoctorMaster
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser{ get; set; }
        public string DepartmentId { get; set; }
        public Department Department { get; set; }

        [StringLength(20)]
        public string DoctorLicenseNo { get; set; }
        public DateTime? Dob { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }
        public int Status { get; set; }

    }
}
