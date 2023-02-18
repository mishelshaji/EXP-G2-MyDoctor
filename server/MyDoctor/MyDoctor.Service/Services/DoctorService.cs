using CartSharp.Domain.Types;
using MyDoctor.Service.Data;
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
        private readonly ApplicationDbContext _db;

        public DoctorService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ServiceResponse<List<AppointmentDoctorDto>>> GetTodayAppointments(int id)
        {
            var response = new ServiceResponse<List<AppointmentDoctorDto>>();
            var res = _db.Appointments.Where(c => c.DoctorMasterId == id)
                .Select(d => new AppointmentDoctorDto()
                {
                    Date = d.Date,
                    Time = d.FromTime,
                    PatientName = d.PatientsMaster.ApplicationUser.FirstName + ' ' + d.PatientsMaster.ApplicationUser.LastName,
                });
            response.Result = res.ToList();
            return response;
        }



    }
}
