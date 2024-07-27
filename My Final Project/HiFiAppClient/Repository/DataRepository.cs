﻿using HiFiAppClient.Models;

namespace HiFiAppClient.Repository
{
    public static class DataRepository
    {
        private static readonly List<CategoryViewModel> _categories = [
            new(){Id=1, Name="Home Teathre"},
            new(){Id=2, Name="Soundbar"},
            new(){Id=3, Name="Bluetooth Speaker"},
        ];
        private static readonly List<HiFiViewModel> _hiFis = [
            new HiFiViewModel()
            {
                Id=1, Name ="Samsung", Properties="Bluetooth Speaker", Stock=3, Price=3500, ImageUrl= "Samsung.png", Categories=new List<CategoryViewModel>
                {
                    new(){Id=1, Name="Bluetooth Speaker"},
                }
            },
            new HiFiViewModel()
            {
                Id=2, Name ="LG", Properties="Soundbar", Stock=3, Price=5000, ImageUrl= "LG.png", Categories=new List<CategoryViewModel>
                {
                    new(){Id=1, Name="Soundbar"},
                }
            },
            new HiFiViewModel()
            {
                Id=3, Name ="Bose", Properties="Home Teathre", Stock=3, Price=15000, ImageUrl= "Bose.png", Categories=new List<CategoryViewModel>
                {
                    new(){Id=1, Name="Home Teathre"},
                }
            }
        ];
        public static List<HiFiViewModel> GetHiFis()
        {
            return _hiFis;
        }
        public static List<CategoryViewModel>GetCategories()
        {
            return _categories;
        }
        public static HiFiViewModel GetHiFi(int id)
        {
            return _hiFis.Where(x => x.Id==id).FirstOrDefault();
        }
        public static CategoryViewModel GetCategory(int id)
        {
            return _categories.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
