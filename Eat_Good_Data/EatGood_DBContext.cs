using EatGood_Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eat_Good_Data
{
    public class EatGood_DBContext :IdentityDbContext<AppUser>
    {
        public EatGood_DBContext(DbContextOptions<EatGood_DBContext> options) : base(options)
        {
            
        }


    }
}
