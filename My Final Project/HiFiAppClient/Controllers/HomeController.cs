using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HiFiAppClient.Models;
using HiFiAppClient.Repository;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;

namespace HiFiAppClient.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        var rootCategories = new Root<List<CategoryViewModel>>();
        using (var httpClient = new HttpClient())
        {
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/Categories/home"))
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return null;
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootCategories = JsonSerializer.Deserialize<Root<List<CategoryViewModel>>>(contentResponse);
            }
        }

        var rootHiFis = new Root<List<HiFiViewModel>>();
        using (var httpClient = new HttpClient())
        {
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/HiFis/hifis"))
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return null;
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootHiFis = JsonSerializer.Deserialize<Root<List<HiFiViewModel>>>(contentResponse);
            }
        }
        var homePageModel = new HomePageModel
        {
            Categories = rootCategories.Data,
            HiFis = rootHiFis.Data
        };
        return View(homePageModel);
    }
}
