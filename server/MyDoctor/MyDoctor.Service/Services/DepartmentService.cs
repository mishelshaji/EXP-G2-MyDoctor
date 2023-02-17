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
            response.Result = _db.Department.Select(c => new DepartmentSuggestionDto { Name = c.DepartmentName}).ToList();
            return response;
                //.Select(c => new DepartmentSuggestionDto{Name = c.DepartmentName,}).ToListAsync();
        }
    }
}
