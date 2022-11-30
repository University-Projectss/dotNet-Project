using RentACar.Helpers.JwtUtils;
using RentACar.Models;
using RentACar.Models.Enums;
using RentACar.Repositories.JobsRepository;
using RentACar.Repositories.UsersRepository;
using System.Runtime.InteropServices;

namespace RentACar.Services.Jobs
{
    public class JobsService : IJobsService
    {
        public IJobRepository _jobRepository;

        public JobsService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task Create(Job newJob)
        {
            await _jobRepository.CreateAsync(newJob);
            await _jobRepository.SaveAsync();
        }

        public Guid getJobIdByTitle(string title)
        {
            return _jobRepository.FindByTitle(title);
        }
    }
}
