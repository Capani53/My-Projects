using HiFiApp.Entity.Concrete;
using HiFiApp.Service.Abstract;
using HiFiApp.Service.Concrete;
using HiFiApp.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HiFiApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService=orderService;
        }

        [HttpPost]
        public async Task<IActionResult> NewOrder(OrderDto orderDto)
        {
            var response = await _orderService.CreateAsync(orderDto);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            var response = await _orderService.GetOrderAsync(orderId);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("getall/{userId?}")]
        public async Task<IActionResult> GetOrder(string userId=null)
        {
            var response = await _orderService.GetOrdersAsync(userId);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }
    }
}
