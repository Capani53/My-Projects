using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HiFiAppClient.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HiFiAppClient.Areas.Admin.Data
{
    public static class BrandRepository
    {
        public static async Task<List<BrandModel>> GetAllAsync()
        {
            var rootBrands = new Root<List<BrandModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/brand"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootBrands = System.Text.Json.JsonSerializer.Deserialize<Root<List<BrandModel>>>(contentResponse);
                }
            }
            return rootBrands.Data;
        }

        public static async Task<List<SelectListItem>> GetSelectListAsync()
        {
            var brands = await GetAllAsync();
            var result = brands.
                    Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
            return result;
        }
    }
}