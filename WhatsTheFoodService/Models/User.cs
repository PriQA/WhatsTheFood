using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsTheFoodService.Models
{
    public class User:IdentityUser    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [StringLength(200)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(200)]
        public string Password { get; set; }
        public bool Enabled { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "First is required.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [MaxLength(200)]
        public string StreetAddress1 { get; set; }
        [MaxLength(200)]
        public string StreetAddress2 { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(15)]
        public string State { get; set; }
        [MaxLength(10)]
        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Role { get; set; }

    }
}
