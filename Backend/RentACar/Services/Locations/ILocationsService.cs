using RentACar.Models;

namespace RentACar.Services.Locations
{
    public interface ILocationsService
    {
        Task Create(Location newLocation);

        Guid getIdByLocation(string city, string street);
    }
}
