using System.ComponentModel.DataAnnotations;

namespace WhatsTheFoodService.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
