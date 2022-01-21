using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsTheFoodService.Models
{
    public class UserDislike
    {
        [Key]
        public int UserDislikeId { get; set; }
        [ForeignKey("User")]
        [Column(Order = 1)]
        public int UserId { get; set; }
        [ForeignKey("Ingredient")]
        [Column(Order = 1)]
        public int IngredientId { get; set; }
    }
}
