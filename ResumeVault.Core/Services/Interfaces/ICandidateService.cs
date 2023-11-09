using Microsoft.AspNetCore.Http;
using ResumeVault.Model.Dtos.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Core.Services.Interfaces
{
    public interface ICandidateService
    {
        Task CreateCandidateAsync(CandidateCreateDto candidateCreateDto, IFormFile pdfFile);
        Task<IEnumerable<CandidateGetDto>> GetCandidatesAsync();
        byte[] GetPdfFileBytes(string url);
    }
}
