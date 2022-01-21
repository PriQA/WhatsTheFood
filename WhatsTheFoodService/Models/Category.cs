using System.ComponentModel.DataAnnotations;

namespace WhatsTheFoodService.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

    }
}
