using RentACar.Models;
using RentACar.Models.DTOs.Auth;
using RentACar.Models.DTOs.Users;

namespace RentACar.Services.Users
{
    public interface IUsersService 
    {
        UserResponseDto Authentificate(UserRequestDto model);
        Task Create(User newUser);
        User GetById(Guid id);
    }
}
