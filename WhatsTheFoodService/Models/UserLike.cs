using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsTheFoodService.Models
{
    public class UserLike
    {
        [Key]
        public int UserLikeId { get; set; }
        [ForeignKey("User")]
        [Column(Order = 1)]
        public int UserId { get; set; }
        [ForeignKey("Ingredient")]
        [Column(Order = 2)]
        public int IngredientId { get; set; }
    }
}
