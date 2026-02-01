using HiFiApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Data.Abstract
{
    public interface ICartRepository:IGenericRepository<Cart>
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
    }
}
