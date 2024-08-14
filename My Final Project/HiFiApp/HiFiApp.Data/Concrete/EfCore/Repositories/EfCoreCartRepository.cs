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
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(HiFiAppDbContext hiFisAppDbContext):base(hiFisAppDbContext)
        {
            
        }
        private HiFiAppDbContext Context
        {
            get { return _dbContext as HiFiAppDbContext; }
        }
        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await Context
                .Carts
                .Where(x => x.UserId == userId)
                .Include(x => x.CartItems)
                .ThenInclude(y => y.HiFi)
                .FirstOrDefaultAsync();
        }
    }
}
