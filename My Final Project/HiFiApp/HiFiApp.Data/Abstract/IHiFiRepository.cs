using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Entity.Concrete;

namespace HiFiApp.Data.Abstract
{
    public interface IHiFiRepository:IGenericRepository<HiFi>
    {
        Task<List<HiFi>> GetHiFisWithCategories();
        Task<List<HiFi>> GetHiFisByCategoryIdAsync (int categoryId);
    }
}