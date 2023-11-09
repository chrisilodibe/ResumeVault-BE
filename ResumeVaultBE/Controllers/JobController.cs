using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeVault.Core.Services.Implementations;
using ResumeVault.Core.Services.Interfaces;
using ResumeVault.Model.Dtos.Company;
using ResumeVault.Model.Dtos.Job;
using ResumeVaultBE.Core.Context;
using ResumeVaultBE.Core.Entities;

namespace ResumeVaultBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;
        private readonly ResumeVaultDbContext resumeVaultDbContext;
        private readonly IMapper mapper;

        public JobController(IJobService jobService, ResumeVaultDbContext resumeVaultDbContext, IMapper mapper)
        {
            this.jobService = jobService;
            this.resumeVaultDbContext = resumeVaultDbContext;
            this.mapper = mapper;
          
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto jobCreateDto)
        {
            await jobService.CreateJobAsync(jobCreateDto);
            return Ok("Job created successfully");
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
        {
            var jobs = await jobService.GetJobsAsync(); 
            return Ok(jobs);
        }


        
          
        
    }
}
