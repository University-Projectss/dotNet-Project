using RentACar.Models.Base;

namespace RentACar.Models
{
    public class Location : BaseEntity
    {
        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;
        public Office Office { get; set; } = default!;
    }
}
