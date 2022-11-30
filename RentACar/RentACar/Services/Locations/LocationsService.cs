using RentACar.Models;
using RentACar.Repositories.JobsRepository;
using RentACar.Repositories.LocationsRepository;

namespace RentACar.Services.Locations
{
    public class LocationsService : ILocationsService
    {
        public ILocationRepository _locationRepository;

        public LocationsService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Create(Location newLocation)
        {
            await _locationRepository.CreateAsync(newLocation);
            await _locationRepository.SaveAsync();
        }

        public Guid getIdByLocation(string city, string street)
        {
            return _locationRepository.FindByCityAndStreet(city, street);
        }
    }
}
