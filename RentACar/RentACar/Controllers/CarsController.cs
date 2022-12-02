using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACar.Models.DTOs.Cars;
using RentACar.Services.Cars;

namespace RentACar.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        /*
            POST - Inchiriem o masina - toata lumea
        */
        private ICarsService _carService;

        public CarsController(ICarsService carService)
        {
            _carService = carService;
        }

        [HttpGet("all"), Authorize]
        public IAsyncEnumerable<Car> GetCars()
        {
            return _carService.GetAll();
        }

        [HttpPost("add"), Authorize(Roles = "Employee, Admin")]
        public async Task<ActionResult<CarResponseDto>> AddCar(CarRequestDto car)
        {
            var carToCreate = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
            };
            await _carService.Create(carToCreate);

            return Ok(new CarResponseDto(carToCreate));
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteCar(Guid id)
        {
            _carService.Delete(id);
            return Ok();
        }
    }
}
