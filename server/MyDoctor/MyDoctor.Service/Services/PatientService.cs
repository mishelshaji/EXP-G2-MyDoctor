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
                .Where(d => d.Status == 1)
                .Select(d=>new DoctorSearchResultDto
                {
                    Id = d.Id,
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
                .Where(m=>m.PatientsMaster.ApplicationUserId == id)
                .Select(d=>new PatientAppointmentsDto
                {
                    AppointmentId = d.Id,
                    status = d.Status,
                    Date = d.Date,
                    Time = d.FromTime,
                    DoctorId = d.DoctorMasterId,
                    DoctorName = d.DoctorMaster.ApplicationUser.FirstName + ' ' + d.DoctorMaster.ApplicationUser.LastName,
                }).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<PatientDetailsDto>>> GetDoctorDetailsAsync(int id)
        {
            var response = new ServiceResponse<List<PatientDetailsDto>>();
            var res = _db.DoctorMaster
                .Where(c => c.Id == id)
                .Select(d => new PatientDetailsDto()
                {
                    patientId = d.Id,
                    Name = d.ApplicationUser.FirstName + ' ' + d.ApplicationUser.LastName,
                    Email = d.ApplicationUser.Email,
                    PhoneNumber = d.PhoneNumber,
                    DepartmentName = d.DepartmentName,
                    userId = d.ApplicationUserId
                });
            response.Result = res.ToList();
            return response;
        }

        public async Task<ServiceResponse<List<ConsultationDetailsDto>>> GetAppointmentDetailsForPatient(int id)
        {
            var response = new ServiceResponse<List<ConsultationDetailsDto>>();
            var res = _db.Consultations.Where(m => m.AppointmentId == id)
                .Select(c => new ConsultationDetailsDto()
                {
                    AppointmentId = c.AppointmentId,
                    ConsultationId = c.Id,
                    Date = c.Appointment.Date,
                    FromTime = c.Appointment.FromTime,
                    Status = c.Appointment.Status,
                    Diseases = c.Disease,
                    Medication = c.Medication,
                    Elaboration = c.Elaboration,
                }).ToList();
            response.Result = res;
            return response;
        }

        public async Task<ServiceResponse<bool>> CancelAppointments(int id)
        {
            var response = new ServiceResponse<bool>();
            var result = _db.Appointments.FirstOrDefault(m => m.Id == id);
            result.Status = 0;
            _db.SaveChanges();
            return response;
        }
    }
}
