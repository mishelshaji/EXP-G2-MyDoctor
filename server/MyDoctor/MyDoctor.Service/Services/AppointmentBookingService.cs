using CartSharp.Domain.Types;
using Microsoft.EntityFrameworkCore;
using MyDoctor.Service.Data;
using MyDoctor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Services
{
    public class AppointmentBookingService
    {
        private readonly ApplicationDbContext _db;

        public AppointmentBookingService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceResponse<Array>> GetBookingData(int id)
        {
            var response = new ServiceResponse<Array>();
            response.Result = _db.DoctorMaster.Where(c => c.Id == id)
                .Select(m => new DoctorDetailsDto()
                {
                    Id = m.ApplicationUserId,
                    MasterId = m.Id,
                    Name = m.ApplicationUser.FirstName + ' ' + m.ApplicationUser.LastName,
                    DepartmentName = m.DepartmentName,
                    Email = m.ApplicationUser.Email,
                    PhoneNumber = m.PhoneNumber
                }).ToArray();
            return response;
        }
    }
}
