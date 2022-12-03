using RentACar.Helpers.JwtUtils;
using RentACar.Models;
using RentACar.Models.DTOs.Auth;
using RentACar.Models.DTOs.Users;
using RentACar.Repositories.UsersRepository;
using System.Runtime.CompilerServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace RentACar.Services.Users
{
    public class UsersService : IUsersService
    {
        public IUserRepository _userRepository;
        private IJwtUtils  _jwtUtils;

        public UsersService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public IEnumerable<User> GetEmployees()
        {
            return _userRepository.GetEmployees();
        }

        public UserResponseDto Authentificate(UserRequestDto model)
        {
            var user = _userRepository.FindByEmail(model.Email);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }

            // jwt generation
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDto(user, jwtToken);
        }

        public async Task Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public async Task<bool> Update(Guid id, UserRequestDto user)
        {
            var dbUser = await _userRepository.FindByIdAsync(id);
            if (dbUser == null || !BCryptNet.Verify(user.Password, dbUser.PasswordHash))
            {
                return false;
            }
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            await _userRepository.SaveAsync();
            return true;
        }

        public async Task Delete(Guid id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            await _userRepository.Delete(user);
            await _userRepository.SaveAsync();
        }
    }
}
