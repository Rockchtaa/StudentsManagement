using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagamentShared.Models;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Data   
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Student> students { get; set; }
        public DbSet<SystemeCode> SystemeCodes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<SystemCodeDetails> SystemCodeDetails { get; set; }

    }
}
