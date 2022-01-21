using System.ComponentModel.DataAnnotations;

namespace WhatsTheFoodService.Models
{
    public class FoodSource
    { 
        [Key]
        public int FoodSourceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]       
        public long PhoneNumber { get; set; }
        [MaxLength(200)]
        public string streetAddress1 { get; set; }
        [MaxLength(200)]
        public string streetAddress2 { get; set; }
        [MaxLength(50)]
        public string city { get; set; }
        [MaxLength(15)]
        public string state { get; set; }
        [MaxLength(10)]
        [Required]
        public string zipCode { get; set; }
        public string LogoLocation { get; set; }
        [MaxLength(400)]
        public string url { get; set; }
    }
}
