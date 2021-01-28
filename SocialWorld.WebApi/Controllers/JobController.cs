using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialWorld.Business.DTOs.JobDtos;
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
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        public JobController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Member")]
        [ValidModel]
        public async Task<IActionResult> GetAllJobsAsync()
        {
            return Ok(_mapper.Map<List<JobListDto>>(await _jobService.GetAllActiveJobsAsync()));
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="Member")]
        [ValidModel]
        public async Task<IActionResult> GetJobById(int id)
        {
            return Ok(_mapper.Map<JobListDto>(await _jobService.FindByIdAsync(id)));
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Roles ="Admin,Member")]
        [ValidModel]
        public async Task<IActionResult> GetJobsByCompanyId(int id)
        {
            return Ok(_mapper.Map<List<JobListDto>>(await _jobService.GetAllJobsByCompanyId(id)));
        }

        [HttpPost]
        [Authorize(Roles = "Member")]
        [ValidModel]
        public async Task<IActionResult> AddAsync(JobAddDto jobAddDto)
        {
            await _jobService.AddAsync(_mapper.Map<Job>(jobAddDto));
            return Created("", jobAddDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Member")]
        [ValidModel]
        public async Task<IActionResult> EditAsync(int id,JobEditDto jobEditDto)
        {
            if (id!=jobEditDto.Id)
            {
                return BadRequest("Invalid Id");
            }

            var job = await _jobService.FindByIdAsync(jobEditDto.Id);
            if (job!=null)
            {
                job.Name = jobEditDto.Name;
                job.LastEdit = DateTime.Now;
                job.PhotoString = jobEditDto.PhotoString;
                job.Explanation = jobEditDto.Explanation;

                await _jobService.UpdateAsync(job);
                return Ok();
            }
            return NotFound("Bu id'ye ait iş bulunmamaktadır.");
        }


        [HttpDelete("{id}")]
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _jobService.FindByIdAsync(id);

            if (job!=null)
            {
                job.isActive = false;
                await _jobService.UpdateAsync(job);
                return NoContent();
            }
            return NotFound("Girilen Id'ye ait bir değer yoktur.");
        }

    }
}
