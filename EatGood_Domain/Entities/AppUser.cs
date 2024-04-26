
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EatGood_Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; } = string.Empty;       
        public DateTime DateModified { get; set; }
        //public IEnumerable<Order>? Orders { get; set; }
    }
}
