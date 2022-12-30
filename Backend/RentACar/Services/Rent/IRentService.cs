using RentACar.Models;
using RentACar.Models.DTOs.Cars;

namespace RentACar.Services.Rent
{
    public interface IRentService
    {
        Task Create(RentCarRequestDto obj);
    }
}
