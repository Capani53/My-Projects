using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Entity.Concrete;

namespace HiFiApp.Data.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {        
        Task<List<Category>> GetActiveCategoriesAsync();
        Task<List<Category>> GetHomeCategoriesAsync();

    }
}