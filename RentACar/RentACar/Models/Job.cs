using RentACar.Models.Base;

namespace RentACar.Models
{
    public class Job : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int MinSalary { get; set; } = 1500;
        public int MaxSalary { get; set; } = 10000;
        public List<Employee> Employees { get; set; } = default!;
    }
}
