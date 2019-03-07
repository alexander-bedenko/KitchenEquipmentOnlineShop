using System;
using System.Threading.Tasks;
using KitchenEquipmentOnlineShop.DataAccess.EF;
using KitchenEquipmentOnlineShop.DataAccess.Entities;

namespace KitchenEquipmentOnlineShop.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<T> Repository<T>() where T : BaseEntity;

        KitchenEquipmentContext Context { get; }

        Task Commit();

        void Rollback();
    }
}