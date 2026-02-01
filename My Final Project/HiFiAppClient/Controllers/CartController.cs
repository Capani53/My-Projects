using HiFiAppClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using HiFiAppClient.Data;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HiFiAppClient.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public CartController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var rootCart = new Root<CartViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5500/api/Carts/getcart/{user.Id}"))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                         string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                         rootCart = JsonSerializer.Deserialize<Root<CartViewModel>>(contentResponse);
                    }
                    else
                    {
                        rootCart.Data = new CartViewModel { CartItems = new List<CartItemViewModel>() };
                    }
                }
            }
            return View(rootCart.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int hifiId, int quantity = 1)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var addToCartDto = new
            {
                UserId = user.Id,
                HiFiId = hifiId,
                Quantity = quantity
            };

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(addToCartDto), System.Text.Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await httpClient.PostAsync("http://localhost:5500/api/Carts/addtocart", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        await httpClient.PostAsync($"http://localhost:5500/api/Carts/initialize/{user.Id}", null);
                        
                        using (HttpResponseMessage retryResponse = await httpClient.PostAsync("http://localhost:5500/api/Carts/addtocart", content))
                        {
                             if (retryResponse.IsSuccessStatusCode)
                             {
                                 return RedirectToAction("Index");
                             }
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
             using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:5500/api/Carts/deleteitem/{cartItemId}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            CartViewModel cart = null;
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5500/api/Carts/getcart/{user.Id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var rootCart = JsonSerializer.Deserialize<Root<CartViewModel>>(content);
                        cart = rootCart?.Data;
                    }
                }

                if (cart == null || cart.CartItems == null || !cart.CartItems.Any())
                {
                    return RedirectToAction("Index");
                }

                var orderDto = new
                {
                    UserId = user.Id,
                    OrderDate = DateTime.Now,
                    OrderItems = cart.CartItems.Select(i => new
                    {
                        HiFiId = i.HiFiId,
                        Quantity = i.Quantity,
                        Price = i.HiFi.Price
                    }).ToList()
                };

                var orderContent = new StringContent(JsonSerializer.Serialize(orderDto), System.Text.Encoding.UTF8, "application/json");
                using (HttpResponseMessage orderResponse = await httpClient.PostAsync("http://localhost:5500/api/Orders", orderContent))
                {
                    if (!orderResponse.IsSuccessStatusCode)
                    {
                         return RedirectToAction("Index");
                    }
                }

                await httpClient.DeleteAsync($"http://localhost:5500/api/Carts/clear/{user.Id}");
            }

            return RedirectToAction("CheckoutSuccess");
        }

        public IActionResult CheckoutSuccess()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(int cartItemId, int quantity)
        {
             using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.PostAsync($"http://localhost:5500/api/Carts/changequantity?cartItemId={cartItemId}&quantity={quantity}", null))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
