using HiFiApp.Data.Abstract;
using HiFiApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreHiFiRepository : EfCoreGenericRepository<HiFi>, IHiFiRepository
    {
        public EfCoreHiFiRepository(HiFiAppDbContext hiFiAppDbContext):base(hiFiAppDbContext)
        {
            
        }
        private HiFiAppDbContext Context
        {
            get
            {
                return _dbContext as HiFiAppDbContext;
            }

        }

        public async Task<HiFi> CreateHiFiWithCategories(HiFi hiFi, List<int> categoryIds)
        {
            var createdHiFi = await Context.HiFis.AddAsync(hiFi);
            if (createdHiFi !=null)
            {
                await Context.SaveChangesAsync();
                var hiFiCategories = categoryIds.Select(x => new HiFiCategory {HiFiId= hiFi.Id,CategoryId=x }).ToList();
                await Context.HiFiCategories.AddRangeAsync(hiFiCategories);
                await Context.SaveChangesAsync();
            }
            var result = await GetHiFiWithCategories(hiFi.Id);
            return result;
        }

        public async Task<List<HiFi>> GetHiFisByCategoryIdAsync(int categoryId)
        {
            List<HiFi> hiFis = await Context.HiFis.Include(x=>x.HiFiCategories).ThenInclude(y=>y.Category).Where(x=>x.HiFiCategories.Any(y=>y.CategoryId==categoryId)).ToListAsync();
            return hiFis;
        }

        public async Task<List<HiFi>> GetHiFisWithCategoriesAsync()
        {
            List<HiFi> hiFis = await Context.HiFis.Include(y => y.HiFiCategories).ThenInclude(y => y.Category).ToListAsync();
            return hiFis;
        }

        public async Task<HiFi> GetHiFiWithCategories(int id)
        {
            HiFi hiFi = await Context.HiFis.Where(x=>x.Id==id).Include(x => x.HiFiCategories).ThenInclude(y => y.Category).FirstOrDefaultAsync();
            return hiFi;
        }
    }
}
