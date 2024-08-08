using HiFiAppClient.Areas.Admin.Models;
using HiFiAppClient.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/hiFis/getallhiFis"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootHiFis = System.Text.Json.JsonSerializer.Deserialize<Root<List<HiFiModel>>>(contentResponse);
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
                    rootCategories = System.Text.Json.JsonSerializer.Deserialize<Root<List<CategoryModel>>>(contentResponse);
                }
            }

            var rootBrands = new Root<List<BrandModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/brands"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootBrands = System.Text.Json.JsonSerializer.Deserialize<Root<List<BrandModel>>>(contentResponse);
                }
            }

            AddHiFiModel hiFiModel = new AddHiFiModel
            {
                CategoryList = rootCategories.Data,
                BrandList = rootBrands.Data.Select(x=>new SelectListItem { 
                    Text = x.Name, Value=x.Id.ToString()}).ToList(),
            };
            return View(hiFiModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddHiFiModel addHiFiModel, IFormFile image)
        {
            if (ModelState.IsValid && addHiFiModel.CategoryIds != null && image!=null)
            {
                using(var httpClient = new HttpClient())
                {
                    var imageUrl="";
                    using (var stream = image.OpenReadStream())
                    {                        
                      var imageContent = new MultipartFormDataContent();
                      byte[] bytes = stream.ToByteArray();
                      imageContent.Add(new ByteArrayContent(bytes), "file", image.FileName);
                        HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:5500/api/HiFis/addimage", imageContent);
                       var responseString = await responseMessage.Content.ReadAsStringAsync();
                        //var response = JsonSerializer.Deserialize<Root<string>>(responseString);
                        var response = JsonConvert.DeserializeObject<Root<ImageModel>>(responseString);
                        if (response.IsSucceeded)
                        {
                            imageUrl = response.Data.ImageUrl;
                        }
                        else
                        {
                            Console.Write(response.Error);
                        }
                    }
                    addHiFiModel.ImageUrl=imageUrl;

                    var serilizeModel = System.Text.Json.JsonSerializer.Serialize(addHiFiModel);
                    var stringContent = new StringContent(serilizeModel,Encoding.UTF8,"application/json");
                    var result = await httpClient.PostAsync("http://localhost:5500/api/HiFis", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }              
            }
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

            var rootBrands = new Root<List<BrandModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/brands"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootBrands = System.Text.Json.JsonSerializer.Deserialize<Root<List<BrandModel>>>(contentResponse);
                }
            }
            addHiFiModel.CategoryList = rootCategories.Data;
            addHiFiModel.BrandList = rootBrands.Data.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.CategoryErrorMessage = addHiFiModel.CategoryIds==null? "En az bir kategori seçilmelidir":null;
            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(addHiFiModel);
        }
    }
}