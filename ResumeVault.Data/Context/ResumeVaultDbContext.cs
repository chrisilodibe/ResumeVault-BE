using Microsoft.EntityFrameworkCore;
using ResumeVaultBE.Core.Entities;

namespace ResumeVaultBE.Core.Context
{
    public class ResumeVaultDbContext : DbContext
    {
        public ResumeVaultDbContext(DbContextOptions<ResumeVaultDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasOne(job => job.Company)
                .WithMany(company => company.Jobs)
                .HasForeignKey(job => job.CompanyId);

            modelBuilder.Entity<Candidate>()
                .HasOne(candidate => candidate.Job)
                .WithMany(job => job.Candidates)
                .HasForeignKey(candidate => candidate.JobId);

            modelBuilder.Entity<Company>()
                .Property(company => company.Size)
                .HasConversion<string>();

            modelBuilder.Entity<Job>()
               .Property(job => job.Level)
               .HasConversion<string>();
        }
    }
}
