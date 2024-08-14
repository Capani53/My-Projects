using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HiFiApp.Entity.Concrete;
using HiFiApp.Shared.Dtos;

namespace HiFiApp.Service.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();

            CreateMap<Brand, BrandDto>().ReverseMap();

            CreateMap<HiFi, HiFiDto>()
                .ForMember(
                    bdto => bdto.Categories,
                    options => options.MapFrom(h => h.HiFiCategories.Select(hc => hc.Category))
                )
                .ReverseMap();

            CreateMap<HiFi, AddHiFiDto>().ReverseMap();
            CreateMap<HiFi, EditHiFiDto>().ReverseMap();

            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();


        }
    }
}
