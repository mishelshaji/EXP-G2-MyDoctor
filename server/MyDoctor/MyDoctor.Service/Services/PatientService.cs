using CartSharp.Domain.Types;
using Microsoft.AspNetCore.Identity;
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
    public class PatientService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientService(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<bool>> PatientHomeSearchAsync(string searchValue)
        {
            return new ServiceResponse<bool>();
        }

        public async Task<PatientProfileDto> EditPatientProfileAsync(PatientProfileDto dto, string id, int masterId)
        {
            var patientsMaster = await _db.PatientsMaster.FirstOrDefaultAsync(M => M.Id == masterId);
            var applicationUser = await _userManager.FindByIdAsync(id);
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


            var user = new PatientProfileDto()
            {
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.Email,
                Gender = patientsMaster.Gender,
                Address = patientsMaster.Address,
                PhoneNumber = patientsMaster.PhoneNumber,
                Dob = patientsMaster.Dob,
                BloodGroup = patientsMaster.BloodGroup,
                EmergencyContactNumber = patientsMaster.EmergencyContactNumber,
                Relationship = patientsMaster.Relationship
            };

            return user;
        }
    }
}
