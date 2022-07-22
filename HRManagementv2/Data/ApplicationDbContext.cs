using HRManagementv2.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementv2.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = 213.159.7.93; Initial Catalog = HRManagement.DEV; User ID = Monovi.Intern; Password = Qweewq2022");
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Interview> InterviewDetails { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Media> Media { get; set; }

    }


}
