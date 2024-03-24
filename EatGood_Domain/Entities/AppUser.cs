
using Microsoft.AspNetCore.Identity;

namespace EatGood_Domain.Entities
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; } 
        public DateTime DateModified { get; set; }
       
      
    }
}
