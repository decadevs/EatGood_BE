using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eat_Good_Data;
using Eat_Good_Data.Repositories.Generic.Implementation;
using Eat_Good_Data.Repositories.Generic.Interface;
using Eat_Good_Services.Interfaces.Services;
using Eat_Good_Services.Services;
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
            // Register Identity

            //Registration of Db
          /*  services.AddDbContext<EatGood_DBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));*/

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            return services;
        }
    }
}
