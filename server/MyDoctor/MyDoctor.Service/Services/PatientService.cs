using CartSharp.Domain.Types;
using MyDoctor.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Services
{
    public class PatientService
    {
        private readonly ApplicationDbContext _db;

        public PatientService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ServiceResponse<bool>> PatientHomeSearchAsync(string searchValue)
        {
           
        }
    }
}
