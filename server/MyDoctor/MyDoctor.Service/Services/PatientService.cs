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
    public class PatientService
    {
        private readonly ApplicationDbContext _db;

        public PatientService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceResponse<List<DoctorSearchResultDto>>> GetDoctorSearchAsync(string searchValue)
        {
            var response = new ServiceResponse<List<DoctorSearchResultDto>>();
            response.Result = _db.DoctorMaster
                .Where(d => d.Department.DepartmentName == searchValue)
                .Select(d=>new DoctorSearchResultDto
                {
                    Name = d.ApplicationUser.FirstName + ' ' + d.ApplicationUser.LastName,
                    DepartmentName = d.Department.DepartmentName
                })
                .ToList();
            return response;
        }

        public async Task<ServiceResponse<List<PatientAppointmentsDto>>> GetAppointmentHistoryAsync(string id)
        {
            var response = new ServiceResponse<List<PatientAppointmentsDto>>();
            response.Result = _db.Appointments
                .Where(m=>m.DoctorMaster.ApplicationUserId == id)
                .Select(d=>new PatientAppointmentsDto
                {
                    Date = d.Date,
                    Time = d.FromTime,
                    DoctorName = d.DoctorMaster.ApplicationUser.FirstName + ' ' + d.DoctorMaster.ApplicationUser.LastName,
                }).ToList();
            return response;
        }
    }
}
