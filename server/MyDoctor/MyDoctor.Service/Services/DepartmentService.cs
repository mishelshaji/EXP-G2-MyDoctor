using CartSharp.Domain.Types;
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
    public class DepartmentService
    {
        private readonly ApplicationDbContext _db;

        public DepartmentService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ServiceResponse<List<DepartmentSuggestionDto>>> GetDepartmentSuggestionAsync()
        {
            var response = new ServiceResponse<List<DepartmentSuggestionDto>>();
            response.Result = _db.Department.Select(d => new DepartmentSuggestionDto { Name = d.DepartmentName }).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<DepartmentDetailsDto>>> GetAllDepartmentDetailsAsync()
        {
            var response = new ServiceResponse<List<DepartmentDetailsDto>>();
            response.Result = _db.Department
                .Select(d => new DepartmentDetailsDto
                {
                    Id = d.Id,
                    DepartmentName = d.DepartmentName,
                    Description = d.Description
                }).ToList();
            return response;
        }

        public async Task<ServiceResponse<bool>> AddNewDepartmentAsync(DepartmentAddDto dto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var department = new Department()
                {
                    DepartmentName = dto.DepartmentName,
                    Description = dto.Description,
                    Status = 1,
                };
                _db.Department.Add(department);
                _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.AddError("", "Error while updating database");
            }

            return new ServiceResponse<bool>()
            {
                Result = true
            };
        }
        public async Task<ServiceResponse<bool>> DeleteDepartmentAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            var department = _db.Department.Where(m => m.Id == id).FirstOrDefault();
            _db.Department.Remove(department);
            _db.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Result = true
            };
        }
    }
}
