using RentACar.Models;
using RentACar.Repositories;
using RentACar.Repositories.LocationsRepository;
using RentACar.Repositories.OfficeRepository;

namespace RentACar.Services.Offices
{
    public class OfficesService : IOfficesService
    {
        public IUnitOfWork _unitOfWork;

        public OfficesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Office newOffice)
        {
            await _unitOfWork.OfficeRepository.CreateAsync(newOffice);
            await _unitOfWork.SaveAsync();
        }
    }
}
