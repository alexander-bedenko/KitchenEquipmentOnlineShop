using KitchenEquipmentOnlineShop.BusinessLogic.Dtos;
using KitchenEquipmentOnlineShop.BusinessLogic.Interfaces;
using KitchenEquipmentOnlineShop.DataAccess.Entities;
using KitchenEquipmentOnlineShop.DataAccess.Interfaces;

namespace KitchenEquipmentOnlineShop.BusinessLogic.Services
{
    public class SinkService : CrudService<Sink, SinkDto>, ISinkService
    {
        public SinkService(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
