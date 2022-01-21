using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsTheFoodService.Models
{
    public class FoodIngredient
    {
        [Key]
        public int FoodIngredientId { get; set; }
        [ForeignKey("Food")]
        [Column(Order = 1)]
        [Required]
        public int FoodId { get; set; }
        [ForeignKey("Ingredient")]
        [Column(Order = 2)]
        [Required]
        public int IngredientId { get; set; }

}
}
