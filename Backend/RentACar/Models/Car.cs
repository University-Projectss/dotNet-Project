using RentACar.Models.Base;

namespace RentACar.Models
{
    public class Car : BaseEntity
    {
        public string Model { get; set; } = default!;
        public string Brand { get; set; } = default!;
        public List<Rented> Rented { get; set; } = default!;

    }
}
