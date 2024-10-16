using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string?Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email address format")]
        public string? Email { get; set; } = "";
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits and numeric")]
        public string PhoneNumber { get; set; } = "";
    }
}
