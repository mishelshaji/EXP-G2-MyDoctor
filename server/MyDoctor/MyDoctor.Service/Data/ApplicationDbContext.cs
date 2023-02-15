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
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
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
            builder.Entity<IdentityRole>().HasData(roles);
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<PatientsMaster> PatientsMaster { get; set;}
    }
}
