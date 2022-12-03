using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models.DTOs.Auth;
using RentACar.Models.DTOs.Users;
using RentACar.Models.Enums;
using RentACar.Models;
using RentACar.Services.Jobs;
using RentACar.Services.Users;
using BCryptNet = BCrypt.Net.BCrypt;

namespace RentACar.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _userService;
        private IJobsService _jobsService;

        public UsersController(IUsersService userService, IJobsService jobsService)
        {
            _userService = userService;
            _jobsService = jobsService;
        }

        //Create new Client endpoint(toti clientii au parola 1234)
        [HttpPost("create-client")]
        public async Task<ActionResult<CreateUserResponseDto>> CreateClient(UserRequestDto client)
        {
            var userToCreate = new User
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                RoleName = Roles.Client,
                Email = client.Email,
                PasswordHash = BCryptNet.HashPassword(client.Password),
                JobId = _jobsService.getJobIdByTitle("Client")
            };
            await _userService.Create(userToCreate);

            return Ok(new CreateUserResponseDto
            {
                Id = userToCreate.Id,
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                RoleName = userToCreate.RoleName,
            });
        }

        //Create new Employee endpoint\
        [HttpPost("create-employee"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<CreateUserResponseDto>> CreateEmployee(UserRequestDto emp)
        {
            var userToCreate = new User
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                RoleName = Roles.Employee,
                Email = emp.Email,
                PasswordHash = BCryptNet.HashPassword(emp.Password),
                JobId = _jobsService.getJobIdByTitle("Employee")
            };
            await _userService.Create(userToCreate);

            return Ok(new CreateUserResponseDto
            {
                Id = userToCreate.Id,
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                RoleName = userToCreate.RoleName,
            });
        }

        //Create new Admin endpoint
        [HttpPost("create-admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<CreateUserResponseDto>> CreateAdmin(UserRequestDto adm)
        {
            var userToCreate = new User
            {
                FirstName = adm.FirstName,
                LastName = adm.LastName,
                RoleName = Roles.Admin,
                Email = adm.Email,
                PasswordHash = BCryptNet.HashPassword(adm.Password),
                JobId = _jobsService.getJobIdByTitle("Admin")
            };
            await _userService.Create(userToCreate);

            return Ok(new CreateUserResponseDto
            {
                Id = userToCreate.Id,
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                RoleName = userToCreate.RoleName,
            });
        }

        [HttpDelete("delete/{id}"), Authorize]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
