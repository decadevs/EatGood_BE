using Eat_Good_Data.Repositories.Generic.Implementation;
using Eat_Good_Data.Repositories.Generic.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eat_Good_Data
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<EatGood_DBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultDbConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }

    }
}
