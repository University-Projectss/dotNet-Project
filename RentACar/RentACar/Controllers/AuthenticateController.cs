using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACar.Models.DTOs.Auth;
using RentACar.Services.Users;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Data;
using RentACar.Models.DTOs.Users;

namespace RentACar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IUsersService _userService;

        public AuthenticateController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> Register(UserRequestDto request)
        {
            var response = _userService.Authentificate(request);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(response);
        }
    }
}
