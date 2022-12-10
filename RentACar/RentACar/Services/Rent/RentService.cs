using RentACar.Models;
using RentACar.Models.DTOs.Cars;
using RentACar.Repositories;
using RentACar.Repositories.CarsRepository;
using RentACar.Repositories.RentRepository;

namespace RentACar.Services.Rent
{
    public class RentService : IRentService
    {
        
        public IUnitOfWork _unitOfWork;

        public RentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(RentCarRequestDto newRent)
        {
            await _unitOfWork.RentRepository.CreateAsync(new Rented { CarId = newRent.carId, ClientId = newRent.clientId});
            await _unitOfWork.SaveAsync();
        }
    }
}
