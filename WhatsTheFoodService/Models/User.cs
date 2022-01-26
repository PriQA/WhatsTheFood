using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsTheFoodService.Models
{
    public class User : IdentityUser
    {
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
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
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

    }
}
