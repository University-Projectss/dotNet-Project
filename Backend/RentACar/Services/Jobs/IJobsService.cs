using RentACar.Models;
using RentACar.Models.DTOs.Jobs;

namespace RentACar.Services.Jobs
{
    public interface IJobsService
    {
        Task Create(Job newJob);
        Guid getJobIdByTitle(string title);
        IAsyncEnumerable<Job> GetAll();
        Task<bool> Update(Guid id, JobRequestDto job);
        Task Delete(Guid jobId);
    }
}
