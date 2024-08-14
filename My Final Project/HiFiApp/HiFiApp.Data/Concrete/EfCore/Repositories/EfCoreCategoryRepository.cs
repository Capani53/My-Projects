using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Data.Abstract;
using HiFiApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HiFiApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(HiFiAppDbContext hiFisAppDbContext):base(hiFisAppDbContext)
        {
            
        }
        private HiFiAppDbContext Context{ get { return _dbContext as HiFiAppDbContext; }}
        public async Task<List<Category>> GetActiveCategoriesAsync()
        {            
            List<Category> categories = 
                await Context
                    .Categories
                    .Where(c=>c.IsActive)
                    .ToListAsync();
            return categories;
        }



        public async Task<List<Category>> GetHomeCategoriesAsync()
        {
            List<Category> categories =
                await Context
                    .Categories
                    .Where(c=>c.IsHome && c.IsActive)
                    .ToListAsync();
            return categories;
        }
    }
}