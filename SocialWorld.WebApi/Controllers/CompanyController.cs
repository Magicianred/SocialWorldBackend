using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialWorld.Business.DTOs.CompanyDtos;
using SocialWorld.Business.Interfaces;
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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(IMapper mapper, ICompanyService companyService)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> GetCompanies(int id)
        {
            return Ok(_mapper.Map<List<CompanyEditDto>>(await _companyService.GetByAppUserIdAsync(id)));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<CompanyEditDto>(await _companyService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize(Roles ="Member")]
        [ValidModel]
        public async Task<IActionResult> AddCompany(CompanyAddDto companyAddDto)
        {
            await _companyService.AddAsync(_mapper.Map<Company>(companyAddDto));
            return Created("", companyAddDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Member")]
        [ValidModel]
        public async Task<IActionResult> EditCompany(int id,CompanyEditDto companyEditDto)
        {

            if (id!=companyEditDto.Id)
            {
                return BadRequest("Id'ler uyuşmuyor");
            }

            var updatedCompany = await _companyService.FindByIdAsync(companyEditDto.Id);

            if (updatedCompany!=null)
            {
                updatedCompany.Name = companyEditDto.Name;
                updatedCompany.Address = companyEditDto.Address;
                updatedCompany.Email = companyEditDto.Email;
                updatedCompany.Explanation = companyEditDto.Explanation;
                updatedCompany.PhoneNumber = companyEditDto.PhoneNumber;
                updatedCompany.PhotoString = companyEditDto.PhotoString;

                await _companyService.UpdateAsync(updatedCompany);
                return NoContent();
            }
            else
            {
                return NotFound("Girilen id'ye ait herhangi bir şirket bulunmamaktadır.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin,Member")]
        [ValidModel]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _companyService.FindByIdAsync(id);
            if (company !=null)
            {
                company.isActive = false;
                await _companyService.UpdateAsync(company);
                return NoContent();
            }
            return BadRequest("Id doğru değil");
        }
    }
}
