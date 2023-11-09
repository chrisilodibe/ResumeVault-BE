using ResumeVault.Model.Dtos.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Core.Services.Interfaces
{
    public interface IJobService
    {
        Task CreateJobAsync(JobCreateDto jobCreateDto);
        Task<IEnumerable<JobGetDto>> GetJobsAsync();
    }
}
