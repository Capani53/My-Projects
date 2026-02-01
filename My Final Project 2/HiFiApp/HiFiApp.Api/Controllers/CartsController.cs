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
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;

        public CartsController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService=cartService;
            _cartItemService=cartItemService;
        }

        [HttpPost("initialize/{userId}")]
        public async Task<IActionResult> Initialize(string userId)
        {
            var response = await _cartService.InitializeCartAsync(userId);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("getcart/{userId}")]
        public async Task<IActionResult> GetCartByUserId(string userId)
        {
            var response = await _cartService.GetCartByUserIdAsync(userId);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpPost("addtocart")]
        public async Task<IActionResult> AddToCart(AddToCartDto addToCartDto)
        {
            var response = await _cartItemService.AddToCartAsync(addToCartDto);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpDelete("deleteitem/{cartitemId}")]
        public async Task<IActionResult> DeleteItem(int cartitemId)
        {
            var response = await _cartItemService.DeleteItemFromCartAsync(cartitemId);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> ClearCart(string userId)
        {
            var response = await _cartItemService.ClearCartAsync(userId);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpPost("changequantity")]
        public async Task<IActionResult> ChangeQuantity(int cartItemId, int quantity)
        {
            var response = await _cartItemService.ChangeQuantityAsync(cartItemId, quantity);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

    }
}
