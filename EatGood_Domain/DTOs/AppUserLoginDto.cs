using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatGood_Domain.DTOs
{
    public class AppUserLoginDto
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [PasswordPropertyText]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }  
    }
}
