using KitchenEquipmentOnlineShop.DataAccess.EF;
using KitchenEquipmentOnlineShop.DataAccess.Interfaces;
using KitchenEquipmentOnlineShop.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KitchenEquipmentOnlineShop.DataAccess.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(DbContext), typeof(KitchenEquipmentContext));
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<KitchenEquipmentContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });

            return services;
        }
    }
}
