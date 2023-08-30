using System.ComponentModel.DataAnnotations;

namespace Repositories.Models
{
    public class Direction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
