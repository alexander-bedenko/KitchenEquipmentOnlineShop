using System;
using AutoMapper;
using KitchenEquipment.Models;
using KitchenEquipmentOnlineShop.BusinessLogic.Dtos;

namespace KitchenEquipment.Infrastructure
{
    public class AutoMapperWebConfig : Profile
    {
        public static readonly Action<IMapperConfigurationExpression> ConfigAction = cfg =>
        {
            cfg.CreateMap<UserDto, UserViewModel>().ReverseMap();
            cfg.CreateMap<CompanyDto, CompanyViewModel>().ReverseMap();
            cfg.CreateMap<ExhaustHoodDto, ExhaustHoodViewModel>().ReverseMap();
            cfg.CreateMap<SinkDto, SinkViewModel>().ReverseMap();
        };
    }
}
