using HRManagementv2.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementv2.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
