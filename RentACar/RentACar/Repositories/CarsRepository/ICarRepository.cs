using RentACar.Models;
using RentACar.Repositories.GenericRepository;

namespace RentACar.Repositories.CarsRepository
{
    public interface ICarRepository : IGenericRepository<Car>
    {
    }
}
