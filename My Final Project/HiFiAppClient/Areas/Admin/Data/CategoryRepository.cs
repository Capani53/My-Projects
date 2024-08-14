using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HiFiAppClient.Areas.Admin.Models;

namespace HiFiAppClient.Areas.Admin.Data
{
    public static class CategoryRepository
    {
        public static async Task<List<CategoryModel>> GetAllAsync()
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
                    rootCategories = System.Text.Json.JsonSerializer.Deserialize<Root<List<CategoryModel>>>(contentResponse);
                }
            }
            return rootCategories.Data;
        }
    }
}