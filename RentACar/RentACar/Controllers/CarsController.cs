using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACar.Models.DTOs.Cars;
using RentACar.Models.DTOs.Jobs;
using RentACar.Services.Cars;
using RentACar.Services.Rent;

namespace RentACar.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarsService _carService;
        private IRentService _rentedService;

        public CarsController(ICarsService carService, IRentService rentedService)
        {
            _carService = carService;
            _rentedService = rentedService;
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

        [HttpPost("rent/{client}/{car}"), Authorize]
        public async Task<ActionResult<Rented>> RentCar(Guid client, Guid car)
        {
            var obj = new RentCarRequestDto { carId = car, clientId = client };
            await _rentedService.Create(obj);
            return Ok(obj);
        }

        [HttpPut("edit/{id}"), Authorize(Roles = "Employee, Admin")]
        public async Task<ActionResult> UpdateCar(Guid id, [FromBody] CarRequestDto car)
        {
            var res = await _carService.Update(id, car);
            if (!res)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("delete/{id}"), Authorize(Roles = "Employee, Admin")]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
            await _carService.Delete(id);
            return Ok();
        }
    }
}
