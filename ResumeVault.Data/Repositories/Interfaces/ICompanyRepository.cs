using ResumeVaultBE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Data.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task AddCompanyAsync(Company company);
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<Company?> GetCompanyByIdAsync(long ID);
        Task UpdateCompanyAsync(long ID);
        Task DeleteCompanyAsync(long ID);
    }
}
