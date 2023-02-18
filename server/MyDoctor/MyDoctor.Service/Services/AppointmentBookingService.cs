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

        public async Task<ServiceResponse<List<Dictionary<string, string>>>> GetTimeSlots(int masterId,string date)
        {
            var response = new ServiceResponse<List<Dictionary<string, string>>>();
            var res = _db.Appointments.Where(m => m.DoctorMasterId == masterId)
                .Select(m => m.FromTime.ToString()).ToList();
            var obj2 = new List<Dictionary<string, string>>();
            foreach (var item in res)
            {
                obj2.Add(new Dictionary<string, string>() { { "fromTime", item } });
            }
            response.Result = obj2;
            return response;
        }

        public async Task<ServiceResponse<Array>> AddBookings(AddBookingDto dto)
        {
            var response = new ServiceResponse<Array>();
            try
            {
                var user = new Appointment()
                {
                    DoctorMasterId= dto.DoctorMasterId,
                    PatientsMasterId= dto.PatientMasterId,
                    Date= dto.Date,
                    FromTime= dto.FromTime,
                    ToTime= dto.ToTime,
                    Status= dto.Status,
                };
                _db.Appointments.Add(user);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                response.AddError("", "Updating database failed");
            }
            return response;
        }

    }
}
