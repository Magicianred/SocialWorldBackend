using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SocialWorld.Business.Concrete;
using SocialWorld.Business.DTOs.AppUserDtos;
using SocialWorld.Business.DTOs.CompanyDtos;
using SocialWorld.Business.DTOs.JobDtos;
using SocialWorld.Business.Interfaces;
using SocialWorld.Business.ValidationRules.FluentValidation;
using SocialWorld.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using SocialWorld.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.Containers.MicrosoftIoC
{
    public static class CustomIocExtension
    {
        public static void AddDependicies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IApplicantDal, EfApplicantRepository>();
            services.AddScoped<IApplicantService, ApplicantManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddScoped<ICompanyDal, EfCompanyRepository>();
            services.AddScoped<ICompanyService, CompanyManager>();

            services.AddScoped<IJobDal, EfJobRepository>();
            services.AddScoped<IJobService, JobManager>();


            services.AddScoped<IJobTypeDal, EfJobTypeRepository>();
            services.AddScoped<IJobTypeService, JobTypeManager>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();
            services.AddTransient<IValidator<CompanyAddDto>, CompanyAddDtoValidator>();
            services.AddTransient<IValidator<CompanyEditDto>, CompanyEditDtoValidator>();
            services.AddTransient<IValidator<JobAddDto>, JobAddDtoValidator>();
            services.AddTransient<IValidator<JobEditDto>, JobEditDtoValidator>();
        }
    }
}
