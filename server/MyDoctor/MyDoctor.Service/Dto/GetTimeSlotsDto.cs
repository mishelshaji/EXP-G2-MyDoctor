using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Dto
{
    public class GetTimeSlotsDto
    {
        public string fromTime { get; set; }

        public string date { get; set; }

        public int status { get; set; } 

        public int fee { get; set; }
    }
}
