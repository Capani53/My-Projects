using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Service.Abstract
{
    public interface ICartItemService
    {
        Task<Response<NoContent>> AddToCartAsync(AddToCartDto addToCartDto);
        Task<Response<NoContent>> ClearCartAsync(string userId);
        Task<Response<NoContent>> DeleteItemFromCartAsync(int cartItemId);
        Task<Response<NoContent>> ChangeQuantityAsync(int cartItemId, int quantity);
    }
}
