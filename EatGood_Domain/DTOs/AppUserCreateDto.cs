using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatGood_Domain.DTOs
{
    public class AppUserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
    }
}
