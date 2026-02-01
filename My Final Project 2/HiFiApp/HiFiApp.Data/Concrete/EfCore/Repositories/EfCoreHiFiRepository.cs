using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFiApp.Data.Abstract;
using HiFiApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HiFiApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreHiFiRepository : EfCoreGenericRepository<HiFi>, IHiFiRepository
    {
        public EfCoreHiFiRepository(HiFiAppDbContext hiFiAppDbContext)
            : base(hiFiAppDbContext) { }

        private HiFiAppDbContext Context
        {
            get { return _dbContext as HiFiAppDbContext; }
        }

        public async Task ClearHiFiCategoriesAsync(int hiFiId)
        {
            List<HiFiCategory> hiFiCategories = await Context
                .HiFiCategories
                .Where(hc => hc.HiFiId == hiFiId)
                .ToListAsync();
            Context.HiFiCategories.RemoveRange(hiFiCategories);
            await Context.SaveChangesAsync();
        }

        public async Task<HiFi> CreateHiFiWithCategoriesAsync(HiFi hiFi, List<int> categoryIds)
        {
            var createdHiFi = await Context.HiFi.AddAsync(hiFi);
            if (createdHiFi != null)
            {
                await Context.SaveChangesAsync();
                var hiFiCategories = categoryIds
                    .Select(x => new HiFiCategory { HiFiId = hiFi.Id, CategoryId = x })
                    .ToList();
                await Context.HiFiCategories.AddRangeAsync(hiFiCategories);
                await Context.SaveChangesAsync();
            }
            var result = await GetHiFiWithCategoriesAsync(hiFi.Id);
            return result;
        }

        public async Task<List<HiFi>> GetActiveHiFiAsync(bool isActive)
        {
            List<HiFi> hiFis = await Context
                .HiFi
                .Where(h => h.IsActive == isActive)
                .Include(h => h.HiFiCategories)
                .ThenInclude(hc => hc.Category)
                .ToListAsync();
            return hiFis;

        }

        public async Task<List<HiFi>> GetHiFiByCategoryIdAsync(int categoryId)
        {
            List<HiFi> hiFis = await Context
                .HiFi
                .Include(x => x.HiFiCategories)
                .ThenInclude(y => y.Category)
                .Where(x => x.HiFiCategories.Any(y => y.CategoryId == categoryId))
                .ToListAsync();
            return hiFis;
        }

        public async Task<List<HiFi>> GetHiFiWithCategoriesAsync()
        {
            List<HiFi> hiFis = await Context
                .HiFi
                .Include(x => x.HiFiCategories)
                .ThenInclude(y => y.Category)
                .Include(x => x.Brand)
                .ToListAsync();
            return hiFis;
        }

        public async Task<HiFi> GetHiFiWithCategoriesAsync(int id)
        {
            HiFi hiFi = await Context
                .HiFi.Where(x => x.Id == id)
                .Include(x => x.HiFiCategories)
                .ThenInclude(y => y.Category)
                .Include(x => x.Brand)
                .FirstOrDefaultAsync();
            return hiFi;
        }

        public async Task<int> GetCount(int? categoryId = null)
        {
            int count = 0;
            if (categoryId == null)
            {
                count = await Context.HiFi.CountAsync();
            }
            else
            {
                var hiFiCategoryList = await Context.HiFiCategories.ToListAsync();
                foreach (var hc in hiFiCategoryList)
                {
                    if (hc.CategoryId == categoryId)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public async Task<List<HiFi>> GetHomeHiFiAsync()
        {
            List<HiFi> hiFis = await Context
                .HiFi
                .Where(h => h.IsActive && h.IsHome)
                .Include(h => h.HiFiCategories)
                .ThenInclude(hc => hc.Category)
                .Include(h => h.Brand)
                .ToListAsync();
            return hiFis;
        }
    }
}
