using KitchenEquipmentOnlineShop.BusinessLogic.Dtos;
using KitchenEquipmentOnlineShop.BusinessLogic.Interfaces;
using KitchenEquipmentOnlineShop.DataAccess.Entities;
using KitchenEquipmentOnlineShop.DataAccess.Interfaces;

namespace KitchenEquipmentOnlineShop.BusinessLogic.Services
{
    public class ExhaustHoodService : CrudService<ExhaustHood, ExhaustHoodDto>, IExhaustHoodService
    {
        public ExhaustHoodService(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
