using RentACar.Models;

namespace RentACar.Services.Cars
{
    public interface ICarsService
    {
        Task Create(Car newCar);
        IAsyncEnumerable<Car> GetAll();

        Task Delete(Guid carId);
    }
}
