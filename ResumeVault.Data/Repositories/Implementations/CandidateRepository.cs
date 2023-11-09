using Microsoft.EntityFrameworkCore;
using ResumeVault.Data.Repositories.Interfaces;
using ResumeVault.Model.Dtos.Candidate;
using ResumeVaultBE.Core.Context;
using ResumeVaultBE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Data.Repositories.Implementations
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ResumeVaultDbContext resumeVaultDbContext;

        public CandidateRepository(ResumeVaultDbContext resumeVaultDbContext)
        {
            this.resumeVaultDbContext = resumeVaultDbContext;
        }

        public async Task AddCandidateAsync(Candidate candidate)
        {
            await resumeVaultDbContext.Candidates.AddAsync(candidate);
            await resumeVaultDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesAsync()
        {
            return await resumeVaultDbContext.Candidates.Include(c => c.Job).OrderByDescending(q => q.CreatedAt).ToListAsync();
        }
    }
}
