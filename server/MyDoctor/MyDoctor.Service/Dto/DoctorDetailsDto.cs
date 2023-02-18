using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class DoctorDetailsDto
    {
        public string Id { get; set; }

        public int MasterId { get; set; }

        public string Name { get; set; }

        public string DepartmentName { get; set; }

        public string Email { get; set; }

        public long? PhoneNumber { get; set; }

    }
}
