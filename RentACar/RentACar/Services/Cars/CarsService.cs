using RentACar.Models;
using RentACar.Models.DTOs.Cars;
using RentACar.Models.DTOs.Jobs;
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

        public async Task<bool> Update(Guid id, CarRequestDto car)
        {
            var dbCar = await _carRepository.FindByIdAsync(id);
            if (dbCar == null)
            {
                return false;
            }
            dbCar.Model = car.Model;
            dbCar.Brand = car.Brand;
            await _carRepository.SaveAsync();
            return true;
        }

        public async Task Delete(Guid carId)
        {
            var carToDelete = await _carRepository.FindByIdAsync(carId);
            await _carRepository.Delete(carToDelete);
            await _carRepository.SaveAsync();
        }
    }
}
