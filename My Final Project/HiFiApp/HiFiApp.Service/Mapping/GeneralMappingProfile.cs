using AutoMapper;
using HiFiApp.Entity.Concrete;
using HiFiApp.Shared.Dtos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Service.Mapping
{
    internal class GeneralMappingProfile:Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();

            CreateMap<HiFi, HiFiDto>().ForMember(hdto => hdto.Categories, options => options.MapFrom(h => h.HiFiCategories.Select(hc => hc.Category))).ReverseMap();
            CreateMap<HiFi, AddHiFiDto>().ReverseMap();
            CreateMap<HiFi, EditHiFiDto>().ReverseMap();

            //CreateMap<HiFi, AddHiFiDto>().ForMember(ahdto => ahdto.CategoryIds, options => options.MapFrom(h => h.HiFiCategories.Select(hc => hc.CategoryId))).ReverseMap();
        }
    }
}
