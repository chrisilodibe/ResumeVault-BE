using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeVault.Core.Services.Implementations;
using ResumeVault.Core.Services.Interfaces;
using ResumeVault.Model.Dtos.Candidate;
using ResumeVault.Model.Dtos.Company;
using ResumeVaultBE.Core.Context;
using ResumeVaultBE.Core.Entities;

namespace ResumeVaultBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService candidateService;
        private readonly ResumeVaultDbContext resumeVaultDbContext;
        private readonly IMapper mapper;

        public CandidateController(ICandidateService candidateService, ResumeVaultDbContext resumeVaultDbContext, IMapper mapper)
        {
            this.candidateService = candidateService;
            //this.resumeVaultDbContext = resumeVaultDbContext;
            //this.mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDto candidateCreateDto, IFormFile pdfFile)
        {
            try
            {
                await candidateService.CreateCandidateAsync(candidateCreateDto, pdfFile);
                return Ok("Candidate saved successfully");
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log them, and return an appropriate error response.
                return BadRequest("Candidate creation failed: " + ex.Message);
            }
        }

      
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidates()
        {
            var candidates = await candidateService.GetCandidatesAsync();
            return Ok(candidates);
        }


        [HttpGet]
        [Route("download/{url}")]
        public IActionResult DownloadPdfFile(string url)
        {
            var pdfBytes = candidateService.GetPdfFileBytes(url);
            return File(pdfBytes, "application/pdf", url);           
        }

    }
}
