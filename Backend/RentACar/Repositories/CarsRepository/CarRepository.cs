using RentACar.DataBase;
using RentACar.Models;
using RentACar.Repositories.GenericRepository;

namespace RentACar.Repositories.CarsRepository
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(DataBaseContext context) : base(context) { }
    }
}
