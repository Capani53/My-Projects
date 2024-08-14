using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Entity.Concrete;

namespace HiFiApp.Data.Abstract
{
    public interface IHiFiRepository:IGenericRepository<HiFi>
    {
        Task<List<HiFi>> GetHiFiWithCategoriesAsync();
        Task<HiFi> GetHiFiWithCategoriesAsync(int id);
        Task<List<HiFi>> GetHiFiByCategoryIdAsync(int categoryId);
        Task<HiFi> CreateHiFiWithCategoriesAsync(HiFi hiFi, List<int> categoryIds);       
        Task ClearHiFiCategoriesAsync(int hiFiId);
        Task<List<HiFi>> GetActiveHiFiAsync(bool isActive);
        Task<int> GetCount(int? categoryId=null);
        Task<List<HiFi>> GetHomeHiFiAsync();
    }
}