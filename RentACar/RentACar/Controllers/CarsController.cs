using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        /*
            GET - luam toate masinile - toata lumea
            POST - adaugam o masina noua - doar empployees
            POST - Inchiriem o masina - toata lumea
            DELETE - stergem o masina dupa id - doar employees
        */
    }
}
