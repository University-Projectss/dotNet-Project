using RentACar.Models;
using RentACar.Models.DTOs.Cars;

namespace RentACar.Services.Cars
{
    public interface ICarsService
    {
        Task Create(Car newCar);
        IAsyncEnumerable<Car> GetAll();
        Task<bool> Update(Guid id, CarRequestDto car);
        Task Delete(Guid carId);
    }
}
