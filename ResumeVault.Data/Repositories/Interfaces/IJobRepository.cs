using ResumeVaultBE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Data.Repositories.Interfaces
{
    public interface IJobRepository
    {
        Task AddJobAsync(Job job);
        Task<IEnumerable<Job>> GetJobsAsync();
    }
}
