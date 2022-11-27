namespace RentACar.Models
{
    public class Rented
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = default!;

        public Guid CarId { get; set; }
        public Car Car { get; set; } = default!;
    }
}
