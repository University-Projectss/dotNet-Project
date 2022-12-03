using RentACar.Models;
using RentACar.Repositories.CarsRepository;

namespace RentACar.Services.Cars
{
    public class CarsService : ICarsService
    {
        public ICarRepository _carRepository;

        public CarsService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Create(Car newCar)
        {
            await _carRepository.CreateAsync(newCar);
            await _carRepository.SaveAsync();
        }

        public IAsyncEnumerable<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public async Task Delete(Guid carId)
        {
            var carToDelete = await _carRepository.FindByIdAsync(carId);
            await _carRepository.Delete(carToDelete);
            await _carRepository.SaveAsync();
        }
    }
}
