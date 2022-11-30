using RentACar.DataBase;
using RentACar.Models;
using RentACar.Repositories.GenericRepository;

namespace RentACar.Repositories.OfficeRepository
{
    public class OfficeRepositorry : GenericRepository<Office>, IOfficeRepository
    {
        public OfficeRepositorry(DataBaseContext context) : base(context) { }
    }
}
