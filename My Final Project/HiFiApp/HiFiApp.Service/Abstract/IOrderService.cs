using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Service.Abstract
{
    public interface IOrderService
    {
        Task<Response<int>> CreateAsync(OrderDto orderDto);
        Task<Response<OrderDto>> GetOrderAsync(int orderId);
        Task<Response<List<OrderDto>>> GetOrdersAsync(string? userId=null);
    }
}
