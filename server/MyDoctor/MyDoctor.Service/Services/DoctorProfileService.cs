using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDoctor.Service.Data;
using MyDoctor.Service.Dto;

namespace MyDoctor.Service.Services
{
    public class DoctorProfileService
    {
        private readonly ApplicationDbContext _db;

        public DoctorProfileService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<DoctorProfileDto> EditDoctorProfileAsync(int id, DoctorProfileDto dto)
        {
            var doctorMaster = await _db.DoctorMaster.FindAsync(id);
            var applicationUser = await _db.ApplicationUsers.FindAsync(id);
            applicationUser.FirstName = dto.FirstName;
            applicationUser.LastName = dto.LastName;
            applicationUser.Email = dto.Email;
            doctorMaster.PhoneNumber = dto.PhoneNumber;
            doctorMaster.Gender = dto.Gender;
            doctorMaster.Dob = dto.Dob;
            doctorMaster.DepartmentName = dto.DepartmentName;
            doctorMaster.DoctorLicenseNo = dto.DoctorLicenseNo;
            await _db.SaveChangesAsync();

            return new DoctorProfileDto
            {
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.Email,
                PhoneNumber = doctorMaster.PhoneNumber,
                Gender = doctorMaster.Gender,
                Dob = doctorMaster.Dob,
                DepartmentName = doctorMaster.DepartmentName,
                DoctorLicenseNo = doctorMaster.DoctorLicenseNo
            };
        }
    }
}
