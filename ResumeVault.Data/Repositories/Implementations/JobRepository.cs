using Microsoft.EntityFrameworkCore;
using ResumeVault.Data.Repositories.Interfaces;
using ResumeVaultBE.Core.Context;
using ResumeVaultBE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Data.Repositories.Implementations
{
    public class JobRepository : IJobRepository
    {
        private readonly ResumeVaultDbContext resumeVaultDbContext;

        public JobRepository(ResumeVaultDbContext resumeVaultDbContext)
        {
            this.resumeVaultDbContext = resumeVaultDbContext;
        }

        public async Task AddJobAsync(Job job)
        {
            await resumeVaultDbContext.Jobs.AddAsync(job);
            await resumeVaultDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Job>> GetJobsAsync()
        {
            return await resumeVaultDbContext.Jobs.Include(job => job.Company).OrderByDescending(q => q.CreatedAt).ToListAsync();
     
        }

    }
}
