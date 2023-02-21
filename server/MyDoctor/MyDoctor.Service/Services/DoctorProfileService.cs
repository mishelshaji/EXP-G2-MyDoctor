using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartSharp.Domain.Types;
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

        public async Task<ServiceResponse<bool>> EditDoctorProfileAsync(int id, DoctorProfileDto dto)
        {
            var doctorMaster = await _db.DoctorMaster.FindAsync(id);
            var applicationUser = _db.ApplicationUsers.FirstOrDefault(m => m.Id == doctorMaster.ApplicationUserId);
            applicationUser.FirstName= dto.FirstName;
            applicationUser.LastName = dto.LastName;
            doctorMaster.PhoneNumber = dto.PhoneNumber;
            doctorMaster.Gender = dto.Gender;
            doctorMaster.Dob = dto.Dob;
            doctorMaster.DoctorLicenseNo = dto.DoctorLicenseNo;
            doctorMaster.Fee = dto.Fee;
            await _db.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Result = true
            };
        }

        public async Task<ServiceResponse<List<DoctorProfileDto>>> ViewDoctorProfileAsync(int id)
        {
            var response = new ServiceResponse<List<DoctorProfileDto>>();
            response.Result = _db.DoctorMaster
                .Where(m=>m.Id == id)
                .Select(d=> new DoctorProfileDto
                {
                    FirstName = d.ApplicationUser.FirstName,
                    LastName = d.ApplicationUser.LastName,
                    Email = d.ApplicationUser.Email,
                    Dob = d.Dob,
                    DoctorLicenseNo = d.DoctorLicenseNo,
                    Fee = d.Fee,
                    Gender = d.Gender,
                    DepartmentName = d.DepartmentName,
                    PhoneNumber = d.PhoneNumber
                }).ToList();
            return response;
        }
    }
}
