using CartSharp.Domain.Types;
using MyDoctor.Domain.Models;
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
        public async Task<ServiceResponse<List<AppointmentDoctorDto>>> GetTodayAppointmentsAsync(int id)
        {
            var response = new ServiceResponse<List<AppointmentDoctorDto>>();
            var today = DateTime.Today.ToString("yyyy-MM-dd").Replace('-', '/');
            Console.WriteLine(today);
            var res = _db.Appointments
                .Where(c => c.DoctorMasterId == id)
                .Where(m => m.Date == today)
                .Select(d => new AppointmentDoctorDto()
                {
                    Id = d.Id,
                    patientId = d.PatientsMasterId,
                    Date = d.Date,
                    Time = d.FromTime,
                    PatientName = d.PatientsMaster.ApplicationUser.FirstName + ' ' + d.PatientsMaster.ApplicationUser.LastName,
                });
            response.Result = res.ToList();
            return response;
        }

        public async Task<ServiceResponse<List<AppointmentDoctorDto>>> GetDoctorAppointmentsAsync(int id)
        {
            var response = new ServiceResponse<List<AppointmentDoctorDto>>();
            var res = _db.Appointments
                .Where(c => c.DoctorMasterId == id)
                .Select(d => new AppointmentDoctorDto()
                {
                    Id = d.Id,
                    patientId = d.PatientsMasterId,
                    Date = d.Date,
                    Time = d.FromTime,
                    PatientName = d.PatientsMaster.ApplicationUser.FirstName + ' ' + d.PatientsMaster.ApplicationUser.LastName,
                });
            response.Result = res.ToList();
            return response;
        }

        public async Task<ServiceResponse<List<PatientDetailsDto>>> GetPatientDetailsAsync(int id)
        {
            var response = new ServiceResponse<List<PatientDetailsDto>>();
            var res = _db.PatientsMaster
                .Where(c => c.Id == id)
                .Select(d => new PatientDetailsDto()
                {
                    patientId = d.Id,
                    Name = d.ApplicationUser.FirstName + ' ' + d.ApplicationUser.LastName,
                    Email = d.ApplicationUser.Email,
                    PhoneNumber = d.PhoneNumber,
                    EmergencyPhoneNumber = d.EmergencyContactNumber,
                    userId = d.ApplicationUserId
                });
            response.Result = res.ToList();
            return response;
        }

        public async Task<ServiceResponse<bool>>UpdatePrescriptionAsync(int id, PrescriptionDto dto)
        {
            var response = new ServiceResponse<bool>();
            var result =_db.Consultations.FirstOrDefault(m => m.AppointmentId == id);
            if (result == null)
            {
                response.AddError("", "Failed to find source");
                return response;
            }
            result.Disease = dto.Diseases;
            result.Elaboration = dto.Elaboration;
            result.Medication = dto.Medication;
            _db.SaveChanges();

            var status = _db.Appointments.FirstOrDefault(m => m.Id== id);
            status.Status = 2;
            _db.SaveChanges();
            return response;
        }

        public async Task<ServiceResponse<List<ConsultationDetailsDto>>> GetAppointmentDetailsForDoctors(int id)
        {
            var response = new ServiceResponse<List<ConsultationDetailsDto>>();
            var res = _db.Consultations.Where(m => m.AppointmentId == id)
                .Select( c => new ConsultationDetailsDto()
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

        public async Task<ServiceResponse<List<PatientAppointmentsDto>>> GetAppointmentHistoryAsync(string id)
        {
            var response = new ServiceResponse<List<PatientAppointmentsDto>>();
            response.Result = _db.Appointments
                .Where(m => m.DoctorMaster.ApplicationUserId == id)
                .Select(d => new PatientAppointmentsDto
                {
                    AppointmentId = d.Id,
                    status = d.Status,
                    Date = d.Date,
                    Time = d.FromTime,
                    PatientId = d.PatientsMaster.Id,
                    PatientName = d.PatientsMaster.ApplicationUser.FirstName + ' ' + d.PatientsMaster.ApplicationUser.LastName,
                }).ToList();
            return response;
        }
    }
}
