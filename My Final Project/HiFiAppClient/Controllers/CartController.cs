using HiFiAppClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HiFiAppClient.Controllers
{
    public class CartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rootCart = new Root<CartViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/Carts/getcart/"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootCart = JsonSerializer.Deserialize<Root<CartViewModel>>(contentResponse);
                }
            }
            return View(rootCart.Data);
        }
    }
}
