using Microsoft.Data.SqlClient;
using RentACar.DataBase;
using RentACar.Repositories.CarsRepository;
using RentACar.Repositories.JobsRepository;
using RentACar.Repositories.LocationsRepository;
using RentACar.Repositories.OfficeRepository;
using RentACar.Repositories.RentRepository;
using RentACar.Repositories.UsersRepository;

namespace RentACar.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
        ICarRepository CarRepository { get; }
        IJobRepository JobRepository { get; }
        ILocationRepository LocationRepository { get; }
        IOfficeRepository OfficeRepository { get; }
        IRentedRepository RentRepository { get; }
        IUserRepository UserRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        public ICarRepository CarRepository { get; set; }
        public IJobRepository JobRepository { get; set; }
        public ILocationRepository LocationRepository { get; set; }
        public IOfficeRepository OfficeRepository { get; set; }
        public IRentedRepository RentRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        private DataBaseContext _dbcontext { get; set; }

        public UnitOfWork(ICarRepository carRepository, IJobRepository jobRepository, ILocationRepository locationRepository, IOfficeRepository officeRepository, IRentedRepository rentRepository, IUserRepository userRepository, DataBaseContext dbcontext)
        {
            CarRepository = carRepository;
            JobRepository = jobRepository;
            LocationRepository = locationRepository;
            OfficeRepository = officeRepository;
            RentRepository = rentRepository;
            UserRepository = userRepository;
            _dbcontext = dbcontext;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _dbcontext.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ceva nu e bine");
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}
