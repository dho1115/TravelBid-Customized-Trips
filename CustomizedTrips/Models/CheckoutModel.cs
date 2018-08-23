using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomizedTrips.Models
{
    public class CheckoutModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$")]
        [Display(Name = "Email Address")]

        public string Email { get; set; }
        public string City { get; set; }
        public string IL { get; set; } 

        [Required]
        public string Nonce { get; set; }
    }
}
