using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsTheFoodService.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        public string Name { get; set; }
        public int Calorie { get; set; }
        [Required]
        [Column("Price", TypeName = "money")]
        public decimal Price { get; set; }
        [ForeignKey("FoodSource")]
        [Column(Order = 1)]
        public int FoodSourceId { get; set; }
        public string ImageLocation { get; set; }
    }
}
