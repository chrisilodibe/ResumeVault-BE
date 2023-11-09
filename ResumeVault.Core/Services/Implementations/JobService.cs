using AutoMapper;
using ResumeVault.Core.Services.Interfaces;
using ResumeVault.Data.Repositories.Implementations;
using ResumeVault.Data.Repositories.Interfaces;
using ResumeVault.Model.Dtos.Company;
using ResumeVault.Model.Dtos.Job;
using ResumeVaultBE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Core.Services.Implementations
{
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;


        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }
        public async Task CreateJobAsync(JobCreateDto jobCreateDto)
        {
            try
            {
                Job newJob = mapper.Map<Job>(jobCreateDto);
                await jobRepository.AddJobAsync(newJob);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log them, and return an appropriate error response.

                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        public async Task<IEnumerable<JobGetDto>> GetJobsAsync()
        {
            try
            {
                var jobs = await jobRepository.GetJobsAsync();
                return mapper.Map<IEnumerable<JobGetDto>>(jobs);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, log them, and return an appropriate error response.
                //logger.Log.Error(ex);
                //throw;
                Console.WriteLine($"Failed to retrieve jobs: {ex.Message}");
                throw;
            }
        }
    }
}
