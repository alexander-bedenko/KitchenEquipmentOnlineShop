using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using KitchenEquipmentOnlineShop.BusinessLogic.Dtos;
using KitchenEquipmentOnlineShop.BusinessLogic.Interfaces;
using KitchenEquipmentOnlineShop.BusinessLogic.Providers;
using KitchenEquipmentOnlineShop.DataAccess.Entities;
using KitchenEquipmentOnlineShop.DataAccess.Interfaces;

namespace KitchenEquipmentOnlineShop.BusinessLogic.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow)
            : base(uow)
        {
        }
        public UserDto AutheticateUser(string email, string password)
        {
            var user = _uow.Repository<User>().GetAsync(x => x.Email.Equals(email));
            while (true)
            {
                if (IsUserValid(user, password))
                    break;
                return null;
            }

            return Mapper.Map<UserDto>(user);
        }

        public async Task RegisterUser(UserDto userDto)
        {
            userDto.Password = HashProvider.Hash(userDto.Password);
            var regUser = Mapper.Map<User>(userDto);
            await _uow.Repository<User>().Create(regUser);
            await _uow.Commit();
        }

        private bool IsUserValid(Task<User> user, string password)
        {
            var hashedPassword = HashProvider.Hash(password);
            return user?.Result.Password == hashedPassword;
        }
    }
}
