using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyDoctor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var roles = new IdentityRole[]
            {
                new IdentityRole()
                {
                    Id = "1",
                    ConcurrencyStamp = "462f2a91-f7b8-4dbd-a17c-4d3d279c566d",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Id = "2",
                    ConcurrencyStamp = "462f2a91-f7b8-4dbd-a17c-4d3d279c566d",
                    Name = "Doctor",
                    NormalizedName = "DOCTOR"
                },
                new IdentityRole()
                {
                    Id = "3",
                    ConcurrencyStamp = "462f2a91-f7b8-4dbd-a17c-4d3d279c566d",
                    Name = "Patient",
                    NormalizedName = "PATIENT"
                }
            };

            var departments = new Department[]
            {
                new Department()
                {
                    Id = 1,
                    DepartmentName = "Dentistry",
                    Description = "About dental science",
                    Status = 1
                },
                new Department()
                {
                    Id = 2,
                    DepartmentName = "Paediatrics",
                    Description = "About children health",
                    Status = 1
                },
                new Department()
                {
                    Id = 3,
                    DepartmentName = "Cardiology",
                    Description = "About heart diseases",
                    Status = 1
                },
                new Department()
                {
                    Id = 4,
                    DepartmentName = "General Surgeon",
                    Description = "About surgical science",
                    Status = 1
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<Department>().HasData(departments);
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<PatientsMaster> PatientsMaster { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<DoctorMaster> DoctorMaster { get; set; }

        public DbSet<Appointment> Appointments { get; set; }


        public DbSet<Consultation> Consultations { get; set; }
    }
}
