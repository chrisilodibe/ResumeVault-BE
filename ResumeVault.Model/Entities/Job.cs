﻿using ResumeVaultBE.Core.Enums;

namespace ResumeVaultBE.Core.Entities
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }

        //Relation with company
        public long CompanyId { get; set; }
        public Company Company { get; set; }

        //relationship with candidate
        public ICollection<Candidate> Candidates { get; set; }
    }
}
