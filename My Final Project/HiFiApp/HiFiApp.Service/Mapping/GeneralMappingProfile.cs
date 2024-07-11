using AutoMapper;
using HiFiApp.Entity.Concrete;
using HiFiApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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

            CreateMap<HiFi, HiFiDto>().ReverseMap();
            CreateMap<HiFi, AddHiFiDto>().ReverseMap();
            CreateMap<HiFi, EditHiFiDto>().ReverseMap();
        }
    }
}
