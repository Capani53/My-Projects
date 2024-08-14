using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HiFiAppClient.Areas.Admin.Models;
using Newtonsoft.Json;

namespace HiFiAppClient.Areas.Admin.Data
{
    public static class HiFiRepository
    {
        public static async Task<List<HiFiModel>> GetAllAsync()
        {
            var rootHiFi = new Root<List<HiFiModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/HiFi/getallhiFis"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootHiFi = System.Text.Json.JsonSerializer.Deserialize<Root<List<HiFiModel>>>(contentResponse);
                }
            }
            return rootHiFi.Data;
        }

        public static async Task<HiFiModel> GetByIdAsync(int id)
        {
            var rootHiFi = new Root<HiFiModel>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5500/api/HiFi/{id}"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootHiFi = JsonConvert.DeserializeObject<Root<HiFiModel>>(contentResponse);                    
                }
            }
            return rootHiFi.Data;
        }

        public static async Task Delete(int id){
            using(var httpClient = new HttpClient()){
                HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:5500/api/HiFi/{id}");
            }            
        }
    }
}