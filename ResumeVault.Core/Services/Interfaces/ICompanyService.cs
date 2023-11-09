using ResumeVault.Model.Dtos.Company;
using ResumeVaultBE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Core.Services.Interfaces
{
    public interface ICompanyService
    {
        Task CreateCompanyAsync(CompanyCreateDto companyCreateDto);
        Task<IEnumerable<CompanyGetDto>> GetCompaniesAsync();
        Task<CompanyGetDto> GetCompanyByIdAsync(long ID);
        Task UpdateCompanyAsync(long ID, CompanyCreateDto companyCreateDto);
        Task DeleteAsync(long ID);
    }
}
