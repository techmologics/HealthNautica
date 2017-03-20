using System;
using System.ComponentModel.DataAnnotations;

namespace HealthNautica.Models
{
    public class User
    {
        [Key]
        public Int32 UserId { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public String UserName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public String Password { get; set; }
        [Required]
        public String Name { get; set; }
    }
}
