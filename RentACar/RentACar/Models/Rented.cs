namespace RentACar.Models
{
    public class Rented
    {
        public Guid ClientId { get; set; }
        public User Client { get; set; } = default!;

        public Guid CarId { get; set; }
        public Car Car { get; set; } = default!;
    }
}
