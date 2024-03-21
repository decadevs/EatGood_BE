using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eat_Good_Services
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services, IConfiguration configuration)
        {


            return services;
        }
    }
}
