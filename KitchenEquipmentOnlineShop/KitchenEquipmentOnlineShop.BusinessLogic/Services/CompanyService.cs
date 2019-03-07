using KitchenEquipmentOnlineShop.BusinessLogic.Dtos;
using KitchenEquipmentOnlineShop.BusinessLogic.Interfaces;
using KitchenEquipmentOnlineShop.DataAccess.Entities;
using KitchenEquipmentOnlineShop.DataAccess.Interfaces;

namespace KitchenEquipmentOnlineShop.BusinessLogic.Services
{
    public class CompanyService : CrudService<Company, CompanyDto>, ICompanyService
    {
        public CompanyService(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
