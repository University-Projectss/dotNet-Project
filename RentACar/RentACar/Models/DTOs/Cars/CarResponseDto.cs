namespace RentACar.Models.DTOs.Cars
{
    public class CarResponseDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public CarResponseDto(Car car)
        {
            Id = car.Id;
            Brand = car.Brand;
            Model = car.Model;
        }
    }
}
