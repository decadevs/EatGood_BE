using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eat_Good_Data;
using Eat_Good_Data.Repositories.Generic.Implementation;
using Eat_Good_Data.Repositories.Generic.Interface;
using Eat_Good_Services.Interfaces;
using Eat_Good_Services.Service_Implementations;
using EatGood_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eat_Good_Services
{

    public static class DependencyInjections
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<EatGood_DBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<EatGood_DBContext>()
            .AddDefaultTokenProviders();
             
            // Register RoleManager
            services.AddScoped<RoleManager<IdentityRole>>();
             
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();

            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));


            return services;
        }
    }
}
