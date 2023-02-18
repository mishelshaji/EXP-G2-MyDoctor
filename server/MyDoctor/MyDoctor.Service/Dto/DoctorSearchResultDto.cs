using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class DoctorSearchResultDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DepartmentName { get; set; }
    }
}
