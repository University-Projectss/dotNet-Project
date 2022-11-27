using RentACar.Models.Base;

namespace RentACar.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PhoneNumeber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public int Age { get; set; } = default!;
        public Job Job { get; set; } = default!;
        public Guid JobId { get; set; }
        public string RoleName { get; set; } = "Employee";
    }
}
