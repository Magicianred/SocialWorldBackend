using AutoMapper;
using SocialWorld.Business.DTOs.ApplicantDtos;
using SocialWorld.Business.DTOs.AppUserDtos;
using SocialWorld.Business.DTOs.CompanyDtos;
using SocialWorld.Business.DTOs.JobDtos;
using SocialWorld.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialWorld.WebApi.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region AppUser
            CreateMap<AppUserLoginDto, AppUser>();
            CreateMap<AppUser, AppUserLoginDto>();

            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            #endregion

            #region Company
            CreateMap<CompanyAddDto, Company>();
            CreateMap<Company, CompanyAddDto>();

            CreateMap<CompanyEditDto, Company>();
            CreateMap<Company, CompanyEditDto>();
            #endregion

            #region Job
            CreateMap<Job, JobAddDto>();
            CreateMap<JobAddDto, Job>();

            CreateMap<Job, JobListDto>();
            CreateMap<JobListDto, Job>();

            CreateMap<Job, JobEditDto>();
            CreateMap<JobEditDto, Job>();
            #endregion


            #region Applicant
            CreateMap<Applicant, ApplicantListDto>();
            CreateMap<ApplicantListDto, Applicant>();

            CreateMap<Applicant, AddApplicantDto>();
            CreateMap<AddApplicantDto, Applicant>();
            #endregion
        }
    }
}
