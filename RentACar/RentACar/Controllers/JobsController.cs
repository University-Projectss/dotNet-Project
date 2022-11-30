using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models.DTOs.Auth;
using RentACar.Models.DTOs.Users;
using RentACar.Models;
using RentACar.Services.Jobs;
using RentACar.Models.DTOs.Jobs;

namespace RentACar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private IJobsService _jobService;

        public JobsController(IJobsService jobService)
        {
            _jobService = jobService;
        }

        //create job endpoint
        [HttpPost("create")]
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
    }
}
