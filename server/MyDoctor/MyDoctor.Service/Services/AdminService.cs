using CartSharp.Domain.Types;
using MyDoctor.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _db;

        public AdminService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceResponse<int>> GetPatientsCountAsync()
        {
            var response = new ServiceResponse<int>();
            response.Result = _db.PatientsMaster.Count();
            return response;
        }

        public async Task<ServiceResponse<int>> GetDoctorsCountAsync()
        {
            var response = new ServiceResponse<int>();
            response.Result = _db.DoctorMaster
                .Where(m => m.Status != null)
                .ToList()
                .Count();
            return response;
        }

        public async Task<ServiceResponse<int>> GetUpcomingBookingsCountAsync()
        {
            var response = new ServiceResponse<int>();
            response.Result = _db.Appointments
                .Where(m => m.Status == 1)
                .ToList()
                .Count();
            return response;
        }

        public async Task<ServiceResponse<int>> GetCompletedBookingsCountAsync()
        {
            var response = new ServiceResponse<int>();
            response.Result = _db.Appointments
                .Where(m => m.Status == 2)
                .ToList()
                .Count();
            return response;
        }

        public async Task<ServiceResponse<int>> GetRegistrationApprovalsCountAsync()
        {
            var response = new ServiceResponse<int>();
            response.Result = _db.DoctorMaster
                .Where(m => m.Status == null)
                .ToList()
                .Count();
            return response;
        }
    }
}
