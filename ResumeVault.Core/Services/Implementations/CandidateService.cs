using AutoMapper;
using Microsoft.AspNetCore.Http;
using ResumeVault.Core.Services.Interfaces;
using ResumeVault.Data.Repositories.Implementations;
using ResumeVault.Data.Repositories.Interfaces;
using ResumeVault.Model.Dtos.Candidate;
using ResumeVault.Model.Dtos.Company;
using ResumeVaultBE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Core.Services.Implementations
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;
        private readonly FileService fileService;

        public CandidateService(ICandidateRepository candidateRepository, IMapper mapper, FileService fileService)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
            this.fileService = fileService;
        }


        public async Task CreateCandidateAsync(CandidateCreateDto candidateCreateDto, IFormFile pdfFile)
        {
            try
            {
                var resumeUrl = await fileService.SaveFileAsync(pdfFile);
                var newCandidate = mapper.Map<Candidate>(candidateCreateDto);
                newCandidate.ResumeUrl = resumeUrl;
                await candidateRepository.AddCandidateAsync(newCandidate);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log them, and return an appropriate error response.

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
               
        }

        public async Task<IEnumerable<CandidateGetDto>> GetCandidatesAsync()
        {
            try
            {
                var Candidates = await candidateRepository.GetCandidatesAsync();
                return mapper.Map<IEnumerable<CandidateGetDto>>(Candidates);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log them, and return an appropriate error response.

                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
          
        }

        public byte[] GetPdfFileBytes(string url)
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Documents", "Pdfs", url);

                if (!System.IO.File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found");
                }

                return System.IO.File.ReadAllBytes(filePath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
                throw;                
            }
            catch (Exception ex)
            {
                // Handle other exceptions, log them, and return an appropriate error response.              
                Console.WriteLine($"Failed to download file: {ex.Message}");
                throw;
            }
            
        }
    }
}
