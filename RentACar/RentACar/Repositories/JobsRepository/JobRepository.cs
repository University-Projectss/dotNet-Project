using RentACar.DataBase;
using RentACar.Models;
using RentACar.Models.Enums;
using RentACar.Repositories.GenericRepository;
using System.Runtime.InteropServices;

namespace RentACar.Repositories.JobsRepository
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(DataBaseContext context) : base(context) { }

        public  Guid FindByTitle(string title)
        {
            return _table.FirstOrDefault(x => x.Title == title).Id;
        }
    }
}
