using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartSharp.Domain.Types;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyDoctor.Service.Data;
using MyDoctor.Service.Dto;

namespace MyDoctor.Service.Services
{
    public class PatientProfileService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientProfileService(ApplicationDbContext db,
                                    UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<bool>> EditPatientProfileAsync(int id, PatientProfileDto dto)
        {
            var response = new ServiceResponse<bool>();
            var patientsMaster = _db.PatientsMaster.FirstOrDefault(m => m.Id == id);
            Console.WriteLine(patientsMaster);
            var applicationUser = await _userManager.FindByIdAsync(patientsMaster.ApplicationUserId);
            Console.WriteLine("hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh" + applicationUser);
            applicationUser.FirstName = dto.FirstName;
            applicationUser.LastName = dto.LastName;
            applicationUser.Email = dto.Email;
            patientsMaster.Address = dto.Address;
            patientsMaster.PhoneNumber = dto.PhoneNumber;
            patientsMaster.EmergencyContactNumber = dto.EmergencyContactNumber;
            patientsMaster.Gender = dto.Gender;
            patientsMaster.Relationship = dto.Relationship;
            patientsMaster.Dob = dto.Dob;
            patientsMaster.BloodGroup = dto.BloodGroup;
            await _db.SaveChangesAsync();
            return response;
        }
        
        public async Task<ServiceResponse<PatientProfileDto>> GetPatientProfile(int id)
        {
            var response = new ServiceResponse<PatientProfileDto>();
            var res = _db.PatientsMaster
                .Where(x => x.Id == id)
                .Select(m => new PatientProfileDto()
                {
                    FirstName = m.ApplicationUser.FirstName,
                    LastName = m.ApplicationUser.LastName,
                    Email = m.ApplicationUser.Email,
                    Gender = m.Gender,
                    Address = m.Address,
                    PhoneNumber = m.PhoneNumber,
                    Dob = m.Dob,
                    BloodGroup = m.BloodGroup,
                    EmergencyContactNumber= m.EmergencyContactNumber,
                    Relationship = m.Relationship
                }).FirstOrDefault();
            response.Result = res;
            return response;
        }
    }
}
