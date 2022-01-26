using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsTheFoodService.Models
{
    public class UserFoodPreference
    {
        [Key]
        public int UserFoodPreferenceId { get; set; }
        [ForeignKey("User")]
        [Column(Order = 1)]
        public int UserId { get; set; }
        [ForeignKey("Food")]
        [Column(Order = 2)]
        public int FoodId { get; set; }

    }
}
