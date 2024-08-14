using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Service.Abstract
{
    public interface ICartService
    {
        Task<Response<NoContent>> InitializeCartAsync(string userId);
        Task<Response<CartDto>> GetCartByUserIdAsync(string userId);
    }
}
