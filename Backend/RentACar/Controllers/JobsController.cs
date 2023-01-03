using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models.DTOs.Auth;
using RentACar.Models.DTOs.Users;
using RentACar.Models;
using RentACar.Services.Jobs;
using RentACar.Models.DTOs.Jobs;
using Microsoft.AspNetCore.Authorization;
using RentACar.Models.Enums;

namespace RentACar.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private IJobsService _jobService;

        public JobsController(IJobsService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("all"), Authorize]
        public IAsyncEnumerable<Job> GetJobs()
        {
            return _jobService.GetAll();
        }

        [HttpPost("create"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> CreateJob(JobRequestDto job)
        {
            var jobToCreate = new Job
            {
                Title = job.Title,
                Description = job.Description,
                MaxSalary = job.MaxSalary,
                MinSalary = job.MinSalary,
            };
            await _jobService.Create(jobToCreate);

            return Ok("Job Creat");
        }

        [HttpPut("edit/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateJob(Guid id, [FromBody]JobRequestDto job)
        {
            var res = await _jobService.Update(id, job);
            if (!res)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("delete/{id}"), Authorize(Roles = "Employee, Admin")]
        public async Task<ActionResult> DeleteJob(Guid id)
        {
            await _jobService.Delete(id);
            return Ok();
        }
    }
}
