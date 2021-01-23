using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialWorld.Business.DTOs.JobTypeDtos;
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
    public class JobTypeController : ControllerBase
    {
        private readonly IJobTypeService _jobTypeService;
        private readonly IMapper _mapper;
        public JobTypeController(IJobTypeService jobTypeService,IMapper mapper)
        {
            _jobTypeService = jobTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> GetAllJobTypes()
        {
            return Ok(await _jobTypeService.GetAllAsync());
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        [ValidModel]
        public async Task<IActionResult> AddJobType(AddJobTypeDto addJobTypeDto)
        {
            await _jobTypeService.AddAsync(_mapper.Map<JobType>(addJobTypeDto));
            return Created("", addJobTypeDto);
        }
    }
}
