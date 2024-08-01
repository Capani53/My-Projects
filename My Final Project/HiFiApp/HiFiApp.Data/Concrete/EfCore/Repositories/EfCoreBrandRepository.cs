using HiFiApp.Data.Abstract;
using HiFiApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreBrandRepository:EfCoreGenericRepository<Brand>,IBrandRepository
    {
        public EfCoreBrandRepository(HiFiAppDbContext hiFiAppDbContext):base(hiFiAppDbContext)
        {
            
        }
        private HiFiAppDbContext Context 
        {
            get { return _dbContext as HiFiAppDbContext; }
        }
    }
}