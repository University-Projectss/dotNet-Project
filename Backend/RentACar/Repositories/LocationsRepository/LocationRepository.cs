using RentACar.DataBase;
using RentACar.Models;
using RentACar.Repositories.GenericRepository;
using RentACar.Repositories.JobsRepository;

namespace RentACar.Repositories.LocationsRepository
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(DataBaseContext context) : base(context) { }

        public Guid FindByCityAndStreet(string city, string street)
        {
            var location = _table.FirstOrDefault(x => x.City == city && x.Street == street);
            if(location == null)
            {
                return Guid.Empty;
            }

            return location.Id;
        }
    }
}
