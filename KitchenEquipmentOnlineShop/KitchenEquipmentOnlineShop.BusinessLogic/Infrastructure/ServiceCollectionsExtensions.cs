using KitchenEquipmentOnlineShop.DataAccess.EF;
using KitchenEquipmentOnlineShop.DataAccess.Extensions;
using KitchenEquipmentOnlineShop.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KitchenEquipmentOnlineShop.BusinessLogic.Infrastructure
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories(configuration);
            services.AddScoped<IKitchenEquipmentContext, KitchenEquipmentContext>();

            return services;
        }
    }
}
