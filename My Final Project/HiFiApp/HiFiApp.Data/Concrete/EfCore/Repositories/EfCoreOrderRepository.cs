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
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(HiFiAppDbContext hiFisAppDbContext) : base(hiFisAppDbContext) { }

        private HiFiAppDbContext Context
        {
            get { return _dbContext as HiFiAppDbContext; }
        }
        public async Task<List<Order>> GetAllOrdersAsync(string userId = null)
        {
            if (userId==null)
            {
                return await Context
                    .Orders
                    .Include(x => x.OrderItems)
                    .ThenInclude(y => y.HiFi)
                    .ToListAsync();
            }
            return await Context
                .Orders
                .Where(x=>x.UserId==userId)
                .Include(x=>x.OrderItems)
                .ThenInclude(y=>y.HiFi)
                .ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await Context
                .Orders
                .Where(x => x.Id==orderId)
                .Include(x => x.OrderItems)
                .ThenInclude(y => y.HiFi)
                .FirstOrDefaultAsync();
        }
    }
}
