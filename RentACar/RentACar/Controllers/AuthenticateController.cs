using Microsoft.AspNetCore.Mvc;
using RentACar.Models.DTOs.Auth;
using RentACar.Services.Users;
using RentACar.Models.DTOs.Users;

namespace RentACar.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IUsersService _userService;

        public AuthenticateController(IUsersService userService)
        {
            _userService = userService;
        }

        //login endpoint
        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> Register(UserRequestDto request)
        {
            var response = _userService.Authentificate(request);
            if (response == null)
            {
                return BadRequest("Input invalid");
            }
            return Ok(response);
        }
    }
}
