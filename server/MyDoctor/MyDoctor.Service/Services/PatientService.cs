using CartSharp.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Services
{
    public class PatientService
    {
        public async Task<ServiceResponse<bool>> PatientHomeSearch(string searchValue)
        {
            var response = new ServiceResponse<bool>();
            return response;
        }
    }
}
