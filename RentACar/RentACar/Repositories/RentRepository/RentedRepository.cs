using RentACar.DataBase;
using RentACar.Models;
using RentACar.Repositories.GenericRepository;

namespace RentACar.Repositories.RentRepository
{
    public class RentedRepository : GenericRepository<Rented> , IRentedRepository
    {
        public RentedRepository(DataBaseContext context) : base(context) { }
    }
}
