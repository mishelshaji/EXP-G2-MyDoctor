using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Domain.Models
{
    public class Department
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string DepartmentName { get; set; }

        [StringLength(50)]
        public string? Description { get; set; }

        public int Status { get; set; }
    }
}
