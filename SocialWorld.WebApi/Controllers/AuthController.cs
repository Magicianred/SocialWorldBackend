using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialWorld.Business.DTOs.AppUserDtos;
using SocialWorld.Business.Interfaces;
using SocialWorld.Business.StringInfo;
using SocialWorld.Entities.Concrete;
using SocialWorld.WebApi.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialWorld.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public AuthController(IJwtService jwtService, IMapper mapper, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.FindByEmail(appUserLoginDto.Email);

            if (user != null && BCrypt.Net.BCrypt.Verify(appUserLoginDto.Password, user.Password))
            {
                var roles = await _appUserService.GetRolesByEmail(appUserLoginDto.Email);
                var token = _jwtService.GenerateJwt(user, roles);

                return Created("", token);
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre yanlış");
            }
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto, [FromServices]IAppUserRoleService appUserRoleService, [FromServices] IAppRoleService appRoleService)
        {
            var appUser = await _appUserService.FindByEmail(appUserAddDto.Email);

            if (appUser !=null)
            {
                return BadRequest($"{appUserAddDto.Email} alınmıştır.");
            }

            appUserAddDto.Password = BCrypt.Net.BCrypt.HashPassword(appUserAddDto.Password);

            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserAddDto));

            var user = await _appUserService.FindByEmail(appUserAddDto.Email);
            var role = await appRoleService.FindByNameAsync(RoleInfo.Member);

            await appUserRoleService.AddAsync(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });

            return Created("", appUserAddDto);
        }

        [HttpGet("[action]")]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> GetActiveUser()
        {
            var user = await _appUserService.FindByEmail(User.Identity.Name);
            var roles = await _appUserService.GetRolesByEmail(user.Email);

            AppUserDto appUserDto = new AppUserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Roles = roles.Select(I => I.Name).ToList()
            };

            return Ok(appUserDto);

            
        }
    }
}
