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
                    Name = d.ApplicationUser.FirstName + ' ' + d.ApplicationUser.LastName,
                    Email = d.ApplicationUser.Email,
                    PhoneNumber = d.PhoneNumber,
                    EmergencyPhoneNumber = d.EmergencyContactNumber
                });
            response.Result = res.ToList();
            return response;
        }

        public async Task<ServiceResponse<bool>>UpdatePrescriptionAsync(int id, PrescriptionDto dto)
        {
            var response = new ServiceResponse<bool>();
            var appointment = await _db.Consultations.FindAsync(id);
            appointment.DiseaseId = dto.Disease;
            appointment.Elaboration = dto.Elaboration;
            appointment.Medication = dto.Medication;
            await _db.SaveChangesAsync();
            return new ServiceResponse<bool> 
            { 
                Result = true 
            };
        }
    }
}
