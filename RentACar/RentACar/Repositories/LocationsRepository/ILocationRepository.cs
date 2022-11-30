using RentACar.Models;
using RentACar.Repositories.GenericRepository;

namespace RentACar.Repositories.LocationsRepository
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Guid FindByCityAndStreet(string city, string street);
    }
}
