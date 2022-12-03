using RentACar.Models.Base;
using RentACar.Models.DTOs.Cars;

namespace RentACar.Models
{
    public class Rented : BaseEntity
    {
        public Guid ClientId { get; set; }
        public User Client { get; set; } = default!;

        public Guid CarId { get; set; }
        public Car Car { get; set; } = default!;

        
    }
}
