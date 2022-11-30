using RentACar.Models.Enums;

namespace RentACar.Models.DTOs.Users
{
    public class CreateUserResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Roles RoleName { get; set; }

       
    }
}
