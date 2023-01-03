using RentACar.Models;
using RentACar.Repositories;
using RentACar.Repositories.JobsRepository;
using RentACar.Repositories.LocationsRepository;

namespace RentACar.Services.Locations
{
    public class LocationsService : ILocationsService
    {
        public IUnitOfWork _unitOfWork;

        public LocationsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Location newLocation)
        {
            await _unitOfWork.LocationRepository.CreateAsync(newLocation);
            await _unitOfWork.SaveAsync();
        }

        public Guid getIdByLocation(string city, string street)
        {
            return _unitOfWork.LocationRepository.FindByCityAndStreet(city, street);
        }
    }
}
