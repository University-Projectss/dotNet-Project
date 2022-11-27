using RentACar.Models.Base;
using System.Text.Json.Serialization;

namespace RentACar.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public List<Rented> Rented { get; set; } = default!;
        public string RoleName { get; set; } = default!;
        public Job Job { get; set; } = default!;
        public Guid JobId { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; } = default!;

    }
}
