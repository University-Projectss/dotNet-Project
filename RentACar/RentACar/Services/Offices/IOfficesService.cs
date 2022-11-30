using RentACar.Models;

namespace RentACar.Services.Offices
{
    public interface IOfficesService
    {
        Task Create(Office newOffice);
    }
}
