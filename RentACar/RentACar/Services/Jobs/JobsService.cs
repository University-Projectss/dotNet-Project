using RentACar.Models;
using RentACar.Models.DTOs.Jobs;
using RentACar.Repositories;
using RentACar.Repositories.JobsRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace RentACar.Services.Jobs
{
    public class JobsService : IJobsService
    {
        public IUnitOfWork _unitOfWork;

        public JobsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(Job newJob)
        {
            await _unitOfWork.JobRepository.CreateAsync(newJob);
            await _unitOfWork.SaveAsync();
        }

        public Guid getJobIdByTitle(string title)
        {
            return _unitOfWork.JobRepository.FindByTitle(title);
        }

        public IAsyncEnumerable<Job> GetAll()
        {
            return _unitOfWork.JobRepository.GetAll();
        }

        public async Task<bool> Update(Guid id, JobRequestDto job)
        {
            var dbJob = await _unitOfWork.JobRepository.FindByIdAsync(id);
            if (dbJob == null)
            {
                return false;
            }
            dbJob.Title = job.Title;
            dbJob.Description = job.Description;
            dbJob.MinSalary = job.MinSalary;
            dbJob.MaxSalary = job.MaxSalary;
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task Delete(Guid jobId)
        {
            var jobToDelete = await _unitOfWork.JobRepository.FindByIdAsync(jobId);
            await _unitOfWork.JobRepository.Delete(jobToDelete);
            await _unitOfWork.SaveAsync();
        }
    }
}
