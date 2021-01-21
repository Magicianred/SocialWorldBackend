using AutoMapper;
using SocialWorld.Business.DTOs.AppUserDtos;
using SocialWorld.Business.DTOs.CompanyDtos;
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
        }
    }
}
