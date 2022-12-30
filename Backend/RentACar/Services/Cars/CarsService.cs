using RentACar.Models;
using RentACar.Models.DTOs.Cars;
using RentACar.Models.DTOs.Jobs;
using RentACar.Repositories;
using RentACar.Repositories.CarsRepository;

namespace RentACar.Services.Cars
{
    public class CarsService : ICarsService
    {
        public IUnitOfWork _unitOfWork;

        public CarsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Car newCar)
        {
            await _unitOfWork.CarRepository.CreateAsync(newCar);
            await _unitOfWork.SaveAsync();
        }

        public IAsyncEnumerable<Car> GetAll()
        {
            return _unitOfWork.CarRepository.GetAll();
        }

        public async Task<bool> Update(Guid id, CarRequestDto car)
        {
            var dbCar = await _unitOfWork.CarRepository.FindByIdAsync(id);
            if (dbCar == null)
            {
                return false;
            }
            dbCar.Model = car.Model;
            dbCar.Brand = car.Brand;
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task Delete(Guid carId)
        {
            var carToDelete = await _unitOfWork.CarRepository.FindByIdAsync(carId);
            await _unitOfWork.CarRepository.Delete(carToDelete);
            await _unitOfWork.SaveAsync();
        }
    }
}
