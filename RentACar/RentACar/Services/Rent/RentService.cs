using RentACar.Models;
using RentACar.Models.DTOs.Cars;
using RentACar.Repositories.CarsRepository;
using RentACar.Repositories.RentRepository;

namespace RentACar.Services.Rent
{
    public class RentService : IRentService
    {
        public IRentedRepository _rentedRepository;

        public RentService(IRentedRepository rentedRepository)
        {
            _rentedRepository = rentedRepository;
        }

        public async Task Create(RentCarRequestDto newRent)
        {
            await _rentedRepository.CreateAsync(new Rented { CarId = newRent.carId, ClientId = newRent.clientId});
            await _rentedRepository.SaveAsync();
        }
    }
}
