using RentACar.Models.Base;
using System.Text.Json.Serialization;

namespace RentACar.Models
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PhoneNumeber {get; set; } = default!;
        public string Email { get; set; } = default!;
        public int Age { get; set; } = default!;
        public List<Rented> Rented { get; set; } = default!;
        public string RoleName { get; set; } = "Client";

        [JsonIgnore]
        public string PasswordHash { get; set; } = default!;

    }
}
