using HiFiAppClient.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HiFiAppClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HiFiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rootHiFis = new Root<List<HiFiModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/HiFis/getallhiFis"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootHiFis = JsonSerializer.Deserialize<Root<List<HiFiModel>>>(contentResponse);
                }
            }
            return View(rootHiFis.Data);
        }

        public async Task<IActionResult> Create()
        {

            var rootCategories = new Root<List<CategoryModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/categories"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootCategories = JsonSerializer.Deserialize<Root<List<CategoryModel>>>(contentResponse);
                }
            }


            AddHiFiModel hiFiModel = new AddHiFiModel
            {
                CategoryList = rootCategories.Data,
                BrandList = []
            };
            return View(hiFiModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddHiFiModel addHiFiModel)
        {
            return View();
        }
    }
}