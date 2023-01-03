using RentACar.Models.Base;
using RentACar.Models.Enums;
using System.Text.Json.Serialization;

namespace RentACar.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public List<Rented> Rented { get; set; } = new List<Rented>();
        public Roles RoleName { get; set; } = default!;
        public Job Job { get; set; } = default!;
        public Guid JobId { get; set; } = Guid.NewGuid();

        [JsonIgnore]
        public string PasswordHash { get; set; } = default!;

    }
}
