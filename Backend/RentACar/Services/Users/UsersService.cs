using RentACar.Helpers.JwtUtils;
using RentACar.Models;
using RentACar.Models.DTOs.Auth;
using RentACar.Models.DTOs.Users;
using RentACar.Repositories;
using RentACar.Repositories.UsersRepository;
using System.Runtime.CompilerServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace RentACar.Services.Users
{
    public class UsersService : IUsersService
    {
        public IUnitOfWork _unitOfWork;
        private IJwtUtils  _jwtUtils;

        public UsersService(IUnitOfWork unitOfWork, IJwtUtils jwtUtils)
        {
            _unitOfWork = unitOfWork;
            _jwtUtils = jwtUtils;
        }

        public IEnumerable<User> GetEmployees()
        {
            return _unitOfWork.UserRepository.GetEmployees();
        }

        public UserResponseDto Authentificate(UserRequestDto model)
        {
            var user = _unitOfWork.UserRepository.FindByEmail(model.Email);
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
            await _unitOfWork.UserRepository.CreateAsync(newUser);
            await _unitOfWork.SaveAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _unitOfWork.UserRepository.FindByIdAsync(id);
        }

        public async Task<bool> Update(Guid id, UserRequestDto user)
        {
            var dbUser = await _unitOfWork.UserRepository.FindByIdAsync(id);
            if (dbUser == null || !BCryptNet.Verify(user.Password, dbUser.PasswordHash))
            {
                return false;
            }
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task Delete(Guid id)
        {
            var user = await _unitOfWork.UserRepository.FindByIdAsync(id);
            await _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveAsync();
        }
    }
}
