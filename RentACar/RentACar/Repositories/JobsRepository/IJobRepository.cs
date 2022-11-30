using RentACar.Models;
using RentACar.Models.Enums;
using RentACar.Repositories.GenericRepository;

namespace RentACar.Repositories.JobsRepository
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Guid FindByTitle(string title);
    }
}
