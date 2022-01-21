using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsTheFoodService.Models
{
    public class FoodCategory
    {
        [Key]
        public int FoodCategoryId { get; set; }
        [ForeignKey("Category")]
        [Column(Order = 1)]
        public int CategoryId { get; set; }

        [ForeignKey("Food")]
        [Column(Order = 2)]
        public int FoodId { get; set; }
    }
}
