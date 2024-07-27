using HiFiAppClient.Models;
using HiFiAppClient.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HiFiAppClient.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {   
            List<CategoryViewModel> categoryList = DataRepository.GetCategories();
            return View(categoryList);
        }

        public IActionResult Delete(int id) 
        {
            CategoryViewModel deletedCategory = DataRepository.GetCategory(id);
            return View(deletedCategory);
        }
    }
}
