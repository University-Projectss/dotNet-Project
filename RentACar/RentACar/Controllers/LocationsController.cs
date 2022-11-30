using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models.DTOs.Jobs;
using RentACar.Models;
using RentACar.Services.Jobs;
using RentACar.Models.DTOs.Locations;
using RentACar.Services.Locations;
using RentACar.Helpers;

namespace RentACar.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private ILocationsService _locationService;
        public LocationsController(ILocationsService locationService)
        {
            _locationService = locationService;
        }

        //POST - adaugam locatie noua - doar Admin
        [HttpPost("create"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> CreateLocation(LocationRequestDto loc)
        {
            var locationToCreate = new Location
            {
               City = loc.City,
               Street = loc.Street,

            };
            await _locationService.Create(locationToCreate);

            return Ok("Location Created");
        }
    }
}
