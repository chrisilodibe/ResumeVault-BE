using ResumeVaultBE.Core.Enums;

namespace ResumeVaultBE.Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }

        //Relationship with Job
        public ICollection<Job> Jobs { get; set; }
       
    }
}
