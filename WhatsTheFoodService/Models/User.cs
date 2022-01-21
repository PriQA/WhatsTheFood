using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsTheFoodService.Models
{
    public class User
    {
        [Key]
        [StringLength(200)]
        public int UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
        public bool Enabled { get; set; }
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [MaxLength(200)]
        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public int PhoneNumber { get; set; }
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

    }
}
