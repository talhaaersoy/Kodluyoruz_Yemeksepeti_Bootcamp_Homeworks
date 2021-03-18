using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abtract;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.Concrete;

namespace WebAPI.ConfigurationExtensions
{
    public static class ServicesConfigurationExtensions
    {
        public static void AddProjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
        }

        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderManager>();
            services.AddTransient<IFoodService, FoodManager>();
        }
    }
}
