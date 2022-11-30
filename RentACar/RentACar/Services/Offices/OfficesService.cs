using RentACar.Models;
using RentACar.Repositories.LocationsRepository;
using RentACar.Repositories.OfficeRepository;

namespace RentACar.Services.Offices
{
    public class OfficesService : IOfficesService
    {
        public IOfficeRepository _officeRepository;

        public OfficesService(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task Create(Office newOffice)
        {
            await _officeRepository.CreateAsync(newOffice);
            await _officeRepository.SaveAsync();
        }
    }
}
