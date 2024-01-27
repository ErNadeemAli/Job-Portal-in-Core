using Microsoft.EntityFrameworkCore;
using Job_portal_in_Core.Models;

namespace Job_portal_in_Core.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<JobSeeker> Seekers { get; set; }
        public DbSet<JobRecruiter> Recruiter { get; set; }
        public DbSet<Admin> admins { get; set; }
       
    }
}
