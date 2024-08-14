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
        Task<Response<NoContent>> CreateAsync(OrderDto orderDto);
        Task<Response<OrderDto>> GetOrderAsync(int orderId);
        Task<Response<List<OrderDto>>> GetAllOrdersAsync(string? userId=null);
    }
}
