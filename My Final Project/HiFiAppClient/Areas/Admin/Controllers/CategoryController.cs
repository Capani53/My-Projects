using HiFiAppClient.Areas.Admin.Data;
using HiFiAppClient.Areas.Admin.Models;
using HiFiAppClient.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                    rootCategories = JsonConvert.DeserializeObject<Root<List<CategoryModel>>>(contentResponse);
                }
            }
            return View(rootCategories.Data);
        }

        public async Task<IActionResult> Create()
        {
            AddCategoryModel categoryModel = new AddCategoryModel();
            return View(categoryModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryModel addCategoryModel, IFormFile image)
        {
            if (ModelState.IsValid && image != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var imageUrl = "";
                    using (var stream = image.OpenReadStream())
                    {
                        var imageContent = new MultipartFormDataContent();
                        byte[] bytes = stream.ToByteArray();
                        imageContent.Add(new ByteArrayContent(bytes), "file", image.FileName);
                        HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:5500/api/Categories/addimage", imageContent);
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

                    addCategoryModel.ImageUrl = imageUrl;
                    var serializeModel = JsonConvert.SerializeObject(addCategoryModel);
                    var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("http://localhost:5500/api/Categories", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(addCategoryModel);
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await CategoryRepository.GetByIdAsync(id);

            EditCategoryModel categoryModel = new EditCategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
                IsActive = category.IsActive,
                IsHome = category.IsHome              
            };
            return View(categoryModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditCategoryModel editCategoryModel, IFormFile image)
        {
            if (ModelState.IsValid)
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
                            HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:5500/api/Categories/addimage", imageContent);
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
                        editCategoryModel.ImageUrl = imageUrl;
                    }

                    var serializeModel = JsonConvert.SerializeObject(editCategoryModel);
                    StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await httpClient.PutAsync("http://localhost:5500/api/Categories", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(editCategoryModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await CategoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}