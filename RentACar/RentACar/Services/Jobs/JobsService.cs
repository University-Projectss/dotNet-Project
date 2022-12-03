using RentACar.Models;
using RentACar.Models.DTOs.Jobs;
using RentACar.Repositories.JobsRepository;
using BCryptNet = BCrypt.Net.BCrypt;

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

        public IAsyncEnumerable<Job> GetAll()
        {
            return _jobRepository.GetAll();
        }

        public async Task<bool> Update(Guid id, JobRequestDto job)
        {
            var dbJob = await _jobRepository.FindByIdAsync(id);
            if (dbJob == null)
            {
                return false;
            }
            dbJob.Title = job.Title;
            dbJob.Description = job.Description;
            dbJob.MinSalary = job.MinSalary;
            dbJob.MaxSalary = job.MaxSalary;
            await _jobRepository.SaveAsync();
            return true;
        }

        public async Task Delete(Guid jobId)
        {
            var jobToDelete = await _jobRepository.FindByIdAsync(jobId);
            await _jobRepository.Delete(jobToDelete);
            await _jobRepository.SaveAsync();
        }
    }
}
