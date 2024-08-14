using HiFiAppClient.Areas.Admin.Data;
using HiFiAppClient.Areas.Admin.Models;
using HiFiAppClient.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
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
            var hiFi = await HiFiRepository.GetAllAsync();
            return View(hiFi);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await CategoryRepository.GetAllAsync();
            var brands = await BrandRepository.GetSelectListAsync();
            AddHiFiModel hiFiModel = new AddHiFiModel
            {
                CategoryList = categories,
                BrandList = brands
            };
            return View(hiFiModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddHiFiModel addHiFiModel, IFormFile image)
        {
            if (ModelState.IsValid && addHiFiModel.CategoryIds != null && image != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var imageUrl = "";                    
                    using (var stream = image.OpenReadStream())
                    {
                        var imageContent = new MultipartFormDataContent();
                        byte[] bytes = stream.ToByteArray();
                        imageContent.Add(new ByteArrayContent(bytes), "file", image.FileName);
                        HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:5500/api/HiFi/addimage", imageContent);
                        var responseString = await responseMessage.Content.ReadAsStringAsync();                        
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
                    addHiFiModel.ImageUrl = imageUrl;                    
                    var serializeModel = System.Text.Json.JsonSerializer.Serialize(addHiFiModel);
                    var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("http://localhost:5500/api/HiFi", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            addHiFiModel.CategoryList = await CategoryRepository.GetAllAsync();
            addHiFiModel.BrandList = await BrandRepository.GetSelectListAsync();
            ViewBag.CategoryErrorMessage = addHiFiModel.CategoryIds == null ? "En az bir kategori seçilmelidir" : null;
            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(addHiFiModel);
        }

        public async Task<IActionResult> Update(int id)
        {
            var hiFi = await HiFiRepository.GetByIdAsync(id);
            var categories = await CategoryRepository.GetAllAsync();
            var brands = await BrandRepository.GetSelectListAsync();

            EditHiFiModel hiFiModel = new EditHiFiModel
            {
                CategoryList = categories,
                BrandList = brands,
                Id = hiFi.Id,
                Name = hiFi.Name,
                CategoryIds = hiFi.Categories.Select(x => x.Id).ToList(),
                BrandId = hiFi.Brand.Id,                
                ImageUrl = hiFi.ImageUrl,
                Properties = hiFi.Properties,
                Description = hiFi.Description,
                IsActive = hiFi.IsActive,
                IsHome = hiFi.IsHome,
                Price = hiFi.Price,
                Stock = hiFi.Stock,                
            };
            return View(hiFiModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditHiFiModel editHiFiModel, IFormFile image)
        {
            if (ModelState.IsValid && editHiFiModel.CategoryIds != null)
            {
                using (var httpClient = new HttpClient())
                {
                    if (image != null)
                    {
                        var imageUrl = "";                        
                        using (var stream = image.OpenReadStream())
                        {
                            var imageContent = new MultipartFormDataContent();
                            byte[] bytes = stream.ToByteArray();
                            imageContent.Add(new ByteArrayContent(bytes), "file", image.FileName);
                            HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:5500/api/hiFis/addimage", imageContent);
                            var responseString = await responseMessage.Content.ReadAsStringAsync();    
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
                        editHiFiModel.ImageUrl = imageUrl;
                    }
                    
                    var serializeModel = JsonConvert.SerializeObject(editHiFiModel);
                    StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await httpClient.PutAsync("http://localhost:5500/api/hiFis", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            var categories = await CategoryRepository.GetAllAsync();
            var brands = await BrandRepository.GetSelectListAsync();
            editHiFiModel.CategoryList = categories;
            editHiFiModel.BrandList = brands;
            ViewBag.CategoryErrorMessage = editHiFiModel.CategoryIds == null ? "En az bir kategori seçilmelidir" : null;
            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(editHiFiModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await HiFiRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
