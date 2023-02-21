using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartSharp.Domain.Types;
using Microsoft.EntityFrameworkCore;
using MyDoctor.Service.Data;
using MyDoctor.Service.Dto;

namespace MyDoctor.Service.Services
{
    public class PatientProfileService
    {
        private readonly ApplicationDbContext _db;

        public PatientProfileService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PatientProfileDto> EditPatientProfileAsync(int id, PatientProfileDto dto)
        {
            var patientsMaster = await _db.PatientsMaster.FindAsync(id);
            var applicationUser = await _db.ApplicationUsers.FindAsync(id);
            applicationUser.FirstName = dto.FirstName;
            applicationUser.LastName = dto.LastName;
            patientsMaster.Address = dto.Address;
            patientsMaster.PhoneNumber = dto.PhoneNumber;
            patientsMaster.EmergencyContactNumber = dto.EmergencyContactNumber;
            patientsMaster.Gender = dto.Gender;
            patientsMaster.Relationship = dto.Relationship;
            patientsMaster.Dob = dto.Dob;
            patientsMaster.BloodGroup = dto.BloodGroup;
            await _db.SaveChangesAsync();

            return new PatientProfileDto
            {
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Gender = patientsMaster.Gender,
                Address = patientsMaster.Address,
                PhoneNumber = patientsMaster.PhoneNumber,
                Dob = patientsMaster.Dob,
                BloodGroup = patientsMaster.BloodGroup,
                EmergencyContactNumber = patientsMaster.EmergencyContactNumber,
                Relationship = patientsMaster.Relationship
            };
        }
    }
}
