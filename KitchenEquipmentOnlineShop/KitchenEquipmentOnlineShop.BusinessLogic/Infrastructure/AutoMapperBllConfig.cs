using System;
using AutoMapper;
using KitchenEquipmentOnlineShop.BusinessLogic.Dtos;
using KitchenEquipmentOnlineShop.DataAccess.Entities;

namespace KitchenEquipmentOnlineShop.BusinessLogic.Infrastructure
{
    public static class AutoMapperBllConfig
    {
        public static readonly Action<IMapperConfigurationExpression> ConfigAction = cfg =>
        {
            cfg.CreateMap<UserDto, User>().ReverseMap();
            cfg.CreateMap<CompanyDto, Company>().ReverseMap();
            cfg.CreateMap<ExhaustHoodDto, ExhaustHood>().ReverseMap();
            cfg.CreateMap<SinkDto, Sink>().ReverseMap();
        };
    }
}
