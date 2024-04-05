using EatGood_Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Eat_Good_API
{
    public class Seeder
    {
        public static void SeedRolesAndSuperAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            // Seed roles
            if (!roleManager.RoleExistsAsync("SuperAdmin").Result)
            {
                var role = new IdentityRole("SuperAdmin");
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole("User");
                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
