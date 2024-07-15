using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Entity.Concrete;

namespace HiFiApp.Data.Abstract
{
    public interface IHiFiRepository:IGenericRepository<HiFi>
    {
        Task<List<HiFi>> GetHiFisWithCategoriesAsync();
        Task<HiFi> GetHiFiWithCategoriesAsync(int id);
        Task<List<HiFi>> GetHiFisByCategoryIdAsync(int categoryId);
        Task<HiFi> CreateHiFiWithCategoriesAsync(HiFi hiFi, List<int>categoryIds);
        //Task<HiFi> UpdateHiFiWithCategoriesAsync(HiFi hiFi, List<int> categoryIds);
        Task ClearHiFiCategoriesAsync(int hiFiId);
        Task<List<HiFi>> GetActiveHiFisAsync(bool isActive);
    }
}