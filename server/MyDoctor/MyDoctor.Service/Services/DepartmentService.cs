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
        public async Task<List<DepartmentSuggestionDto>> GetDepartmentSuggestionAsync()
        {
            return await _db.Department
                .Select(c => new DepartmentSuggestionDto
                {
                    Name = c.DepartmentName,
                })
                .ToListAsync();
        }
    }
}
