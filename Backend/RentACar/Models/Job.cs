using RentACar.Models.Base;

namespace RentACar.Models
{
    public class Job : BaseEntity
    {
        public string Title { get; set; } = "Title";
        public string Description { get; set; } = "Description"!;
        public int MinSalary { get; set; } = 1500;
        public int MaxSalary { get; set; } = 10000;
        public List<User> Employees { get; set; } = new List<User>();
    }
}
