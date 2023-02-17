using CartSharp.Domain.Types;
using MyDoctor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Services
{
    public class DoctorService
    {
        public async Task<ServiceResponse<LoginDto[]>> DoctorAppointment(int id)
        {
            var response = new ServiceResponse<LoginDto[]>();
            response.Result = new Array<>
        }
    }
}
