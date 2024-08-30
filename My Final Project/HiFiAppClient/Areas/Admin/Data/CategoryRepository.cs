using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HiFiAppClient.Areas.Admin.Models;
using Newtonsoft.Json;

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

        public static async Task Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:5500/api/Category/{id}");
            }
        }
        public static async Task<CategoryModel> GetByIdAsync(int id)
        {
            var rootCategory = new Root<CategoryModel>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5500/api/Category/{id}"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootCategory = JsonConvert.DeserializeObject<Root<CategoryModel>>(contentResponse);
                }
            }
            return rootCategory.Data;
        }
    }
}
