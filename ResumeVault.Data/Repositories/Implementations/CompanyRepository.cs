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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ResumeVaultDbContext resumeVaultDbContext;

        public CompanyRepository(ResumeVaultDbContext resumeVaultDbContext)
        {
            this.resumeVaultDbContext = resumeVaultDbContext;
        }

        public async Task AddCompanyAsync(Company company)
        {
            await resumeVaultDbContext.Companies.AddAsync(company);
            await resumeVaultDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await resumeVaultDbContext.Companies.OrderByDescending(q => q.CreatedAt).ToListAsync();
        }

        public async Task<Company?> GetCompanyByIdAsync(long ID)
        {
            return await resumeVaultDbContext.Companies.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task UpdateCompanyAsync(long ID)
        {
            var company = await resumeVaultDbContext.Companies.FirstOrDefaultAsync(x => x.ID == ID);
            var result = resumeVaultDbContext.Companies.Update(company);
            await resumeVaultDbContext.SaveChangesAsync();
        }

        public async Task DeleteCompanyAsync(long ID)
        {
            var company = await resumeVaultDbContext.Companies.FirstOrDefaultAsync(x => x.ID == ID);
            resumeVaultDbContext.Companies.Remove(company);  
            await resumeVaultDbContext.SaveChangesAsync();
        }
    }
}
