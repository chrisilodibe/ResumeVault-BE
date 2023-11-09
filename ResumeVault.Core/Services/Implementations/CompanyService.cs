using AutoMapper;
using Microsoft.Extensions.Logging;
using ResumeVault.Core.Services.Interfaces;
using ResumeVault.Data.Repositories.Implementations;
using ResumeVault.Data.Repositories.Interfaces;
using ResumeVault.Model.Dtos.Company;
using ResumeVaultBE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Core.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;       

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;       
        }

        public async Task CreateCompanyAsync(CompanyCreateDto companyCreateDto)
        {
            try
            {
                Company newCompany = mapper.Map<Company>(companyCreateDto);
                await companyRepository.AddCompanyAsync(newCompany);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log them, and return an appropriate error response.

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
           
        }

        public async Task<IEnumerable<CompanyGetDto>> GetCompaniesAsync()
        {
            try
            {
                var companies = await companyRepository.GetCompaniesAsync();
                return mapper.Map<IEnumerable<CompanyGetDto>>(companies);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log them, and return an appropriate error response.
                //logger.Log.Error(ex);
                //throw;
                Console.WriteLine($"Failed to retrieve companies: {ex.Message}");
                throw;
            }
           
        }

        public async Task<CompanyGetDto> GetCompanyByIdAsync(long ID)
        {
            try
            {
                var company = await companyRepository.GetCompanyByIdAsync(ID);
                return mapper.Map<CompanyGetDto>(company);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to retrieve company: {ex.Message}");
                throw;
            }
            
        }

        public async Task UpdateCompanyAsync(long ID, CompanyCreateDto companyCreateDto)
        {
            try
            {
                var existingCompany = await companyRepository.GetCompanyByIdAsync(ID);

                if (existingCompany == null)
                {
                    throw new Exception("Company not found"); // Handle this exception appropriately
                }

                mapper.Map(companyCreateDto, existingCompany);

                await companyRepository.UpdateCompanyAsync(existingCompany.ID);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log them, and return an appropriate error response.
                Console.WriteLine($"Update failed: {ex.Message}");
                throw;
            }
           
            
        }

        public async Task DeleteAsync(long ID)
        {
            try
            {
                var existingCompany = await companyRepository.GetCompanyByIdAsync(ID);
                if (existingCompany == null)
                {
                    throw new Exception("Company not found");
                }
                await companyRepository.DeleteCompanyAsync(existingCompany.ID);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log them, and return an appropriate error response.
                Console.WriteLine($"Delete failed: {ex.Message}");
                throw;
            }

        }
    }
}
