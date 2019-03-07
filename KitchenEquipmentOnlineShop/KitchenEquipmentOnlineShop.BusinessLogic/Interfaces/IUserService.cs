using System.Threading.Tasks;
using KitchenEquipmentOnlineShop.BusinessLogic.Dtos;

namespace KitchenEquipmentOnlineShop.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        UserDto AutheticateUser(string email, string password);
        Task RegisterUser(UserDto userDto);
    }
}