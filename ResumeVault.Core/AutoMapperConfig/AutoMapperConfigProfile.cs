using AutoMapper;
using ResumeVault.Model.Dtos.Candidate;
using ResumeVault.Model.Dtos.Company;
using ResumeVault.Model.Dtos.Job;
using ResumeVaultBE.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeVault.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyGetDto>();
            CreateMap<Company, CompanyCreateDto>();
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>()
                .ForMember(des => des.CompanyName, option => option.MapFrom(src => src.Company.Name));
            CreateMap<CandidateCreateDto, Candidate>();
            CreateMap<Candidate, CandidateGetDto>()
                .ForMember(des => des.JobTitle, options => options.MapFrom(src => src.Job.Title));


        }
        

    }
}
