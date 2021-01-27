using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialWorld.Business.DTOs.ApplicantDtos;
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
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private readonly IMapper _mapper;
        public ApplicantController(IApplicantService applicantService, IMapper mapper)
        {
            _applicantService = applicantService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> GetAllApplicantsByJobId(int id)
        {
            return Ok(_mapper.Map<List<ApplicantListDto>>(await _applicantService.GetAllApplicantsByJobId(id)));
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Member")]
        [ValidModel]
        public async Task<IActionResult> ApplyJob(AddApplicantDto addApplicantDto)
        {
            await _applicantService.AddAsync(_mapper.Map<Applicant>(addApplicantDto));

            return Created("",addApplicantDto);
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Roles ="Admin,Member")]
        [ValidModel]
        public async Task<IActionResult> GetUserApplicants(int id)
        {
            return Ok(_mapper.Map<List<ApplicantListDto>>(await _applicantService.GetUserApplications(id)));
        }
    }
}
