using HiFiApp.Data.Abstract;
using HiFiApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCartItemRepository:EfCoreGenericRepository<CartItem>, ICartItemRepository
    {
        public EfCoreCartItemRepository(HiFiAppDbContext hiFisAppDbContext):base(hiFisAppDbContext) { }

        private HiFiAppDbContext Context
        {
            get { return _dbContext as HiFiAppDbContext; }
        }



    }
}
