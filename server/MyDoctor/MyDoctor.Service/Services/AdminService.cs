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
    public class AdminService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<int>> GetPatientsCountAsync()
        {
            var response = new ServiceResponse<int>();
            response.Result = _db.PatientsMaster.Count();
            return response;
        }

        public async Task<ServiceResponse<int>> GetDoctorsCountAsync()
        {
            var response = new ServiceResponse<int>();
            response.Result = _db.DoctorMaster
                .Where(m => m.Status != null)
                .ToList()
                .Count();
            return response;
        }

        public async Task<ServiceResponse<int>> GetUpcomingBookingsCountAsync()
        {
            var response = new ServiceResponse<int>();
            response.Result = _db.Appointments
                .Where(m => m.Status == 1)
                .ToList()
                .Count();
            return response;
        }

        public async Task<ServiceResponse<int>> GetCompletedBookingsCountAsync()
        {
            var response = new ServiceResponse<int>();
            response.Result = _db.Appointments
                .Where(m => m.Status == 2)
                .ToList()
                .Count();
            return response;
        }

        public async Task<ServiceResponse<int>> GetRegistrationApprovalsCountAsync()
        {
            var response = new ServiceResponse<int>();
            response.Result = _db.DoctorMaster
                .Where(m => m.Status == null)
                .ToList()
                .Count();
            return response;
        }

        public async Task<ServiceResponse<List<DoctorDetailsDto>>> GetNewDoctorsAsync()
        {
            var response = new ServiceResponse<List<DoctorDetailsDto>>();
            response.Result = _db.DoctorMaster
                .Where(m => m.Status == null)
                .Select(m => new DoctorDetailsDto()
                {
                   MasterId = m.Id,
                   Name = m.ApplicationUser.FirstName + ' ' + m.ApplicationUser.LastName,
                   DepartmentName = m.ApplicationUser.Specialization
                })
                .ToList();
            return response;
        }

        public async Task<ServiceResponse<bool>> ApproveDoctorAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            var doctor = _db.DoctorMaster.Where(m => m.Id == id).First();
            doctor.Status = 1;
            _db.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Result = true,
            };
        }

        public async Task<ServiceResponse<bool>> DeclineDoctorAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            var doctor = _db.DoctorMaster.Where(m => m.Id == id).First();
            var user = _db.ApplicationUsers.Where(m => m.Id == doctor.ApplicationUserId).First();
            //await _userManager.RemoveFromRoleAsync(user, "Doctor");
            //await _userManager.DeleteAsync(user);
            var userroles = _db.UserRoles.Where(m => m.UserId == user.Id).First();
            _db.DoctorMaster.Remove(doctor);
            _db.UserRoles.Remove(userroles);
            _db.ApplicationUsers.Remove(user);
            await _db.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Result = true,
            };
        }
    }
}
