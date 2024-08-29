using HiFiAppClient.Areas.Admin.Data;
using HiFiAppClient.Areas.Admin.Models;
using HiFiAppClient.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HiFiAppClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
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
            return View(rootCategories.Data);
        }

        
        public async Task<IActionResult> Delete(int id)
            {
                await CategoryRepository.Delete(id);
                return RedirectToAction("Index");
            }
        
        }
    }
