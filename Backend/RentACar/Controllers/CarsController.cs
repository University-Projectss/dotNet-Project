using SerpApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RentACar.Models;
using RentACar.Models.DTOs.Cars;
using RentACar.Models.DTOs.Jobs;
using RentACar.Services.Cars;
using RentACar.Services.Rent;
using System.Collections;
using Microsoft.OpenApi.Any;
using static GoogleApi.GooglePlaces;

namespace RentACar.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarsService _carService;
        private IRentService _rentedService;
        String apiKey = "7308b831aaa60ac681145da3e782a6c2082921ff7be2d593bb5d6e59f2ceb4d0";

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

        [HttpGet("car-details/{brand}/{model}"), Authorize]
        public async Task<ActionResult<string>> GetCarDetails(string brand, string model)
        {
            
            Hashtable ht = new Hashtable();
            ht.Add("engine", "google");
            ht.Add("q", brand + " " + model);
            JObject data;

            try
            {
                GoogleSearch search = new GoogleSearch(ht, apiKey);
                data =  search.GetJson();
            }
            catch (SerpApiSearchException ex)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }

            Console.WriteLine(data?["search_metadata"]["google_url"]);
            Console.WriteLine(data["search_metadata"]["google_url"].GetType());

            return Ok(data?["search_metadata"]["google_url"].ToString());
        }

        [HttpDelete("delete/{id}"), Authorize(Roles = "Employee, Admin")]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
            await _carService.Delete(id);
            return Ok();
        }
    }
}
