using System.ComponentModel.DataAnnotations;

namespace RentACar.Models.DTOs.Jobs
{
    public class JobRequestDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MinSalary { get; set; }
        [Required]
        public int MaxSalary { get; set; } 
    }
}
