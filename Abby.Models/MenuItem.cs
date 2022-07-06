using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abby.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        [Range(1, 1000, ErrorMessage = "the price should be between $1 and $1000")]
        public int Price { get; set; }

        public FoodType? Type { get; set; }
        public int FoodTypeId { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
