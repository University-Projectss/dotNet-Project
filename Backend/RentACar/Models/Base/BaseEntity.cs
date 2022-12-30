using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Models.Base
{
    public class BaseEntity
    {
        [Key]
        // Generates a value when a row is inserted
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
