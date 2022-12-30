using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models.DTOs.Locations;
using RentACar.Models.Enums;
using RentACar.Models;
using RentACar.Services.Locations;
using RentACar.Models.DTOs.Offices;
using RentACar.Services.Offices;

namespace RentACar.Controllers
{
    [Route("api/offices")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private IOfficesService _officeService;
        private ILocationsService _locationsService;
        public OfficesController(IOfficesService officeService, ILocationsService locationsService)
        {
            _officeService = officeService;
            _locationsService = locationsService;
        }

        //POST - adaugam un nou sediu - doar Admin
        [HttpPost("create"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> CreateOffice(OfficesRequestDto off)
        {
            var locationId = _locationsService.getIdByLocation(off.City, off.Street);
            if(locationId == Guid.Empty)
            {
                return NotFound();
            }

            var officeToCreate = new Office
            {
               Name = off.Name,
               LocationId = locationId,
            };

            await _officeService.Create(officeToCreate);

            return Ok("Office Created");
        }
    }
}
