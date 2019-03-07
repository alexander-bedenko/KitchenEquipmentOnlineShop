using KitchenEquipmentOnlineShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace KitchenEquipmentOnlineShop.DataAccess.Interfaces
{
    public interface IKitchenEquipmentContext
    {
        DbSet<User> Users { get; set; }
        DbSet<ExhaustHood> ExhaustHoods { get; set; }
        DbSet<Sink> Sinks { get; set; }
        DbSet<Company> Companies { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void Dispose();
        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<T> Set<T>() where T : class;
    }
}