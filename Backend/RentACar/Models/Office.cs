using RentACar.Models.Base;

namespace RentACar.Models
{
    public class Office : BaseEntity
    {
        public string Name { get; set; } = default!;
        public Location Location { get; set; } = default!;

        public Guid LocationId { get; set; }
    }
}
