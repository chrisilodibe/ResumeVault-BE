using ResumeVaultBE.Core.Entities;
using ResumeVaultBE.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Model.Dtos.Job
{
    public class JobGetDto
    {
        public long ID { get; set; }       
        public string Title { get; set; }
        public JobLevel Level { get; set; }      
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
