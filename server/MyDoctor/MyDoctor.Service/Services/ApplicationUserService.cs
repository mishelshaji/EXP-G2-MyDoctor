using MyDoctor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Services
{
    public class ApplicationUserService
    {
        public async Task<RegisterDto> PostData(RegisterDto dto)
        {
            Console.WriteLine(dto);
            return dto;
        }
    }
}
