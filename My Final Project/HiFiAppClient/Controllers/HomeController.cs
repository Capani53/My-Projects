using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HiFiAppClient.Models;
using HiFiAppClient.Repository;

namespace HiFiAppClient.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        var categoryList = DataRepository.GetCategories();
        return View(categoryList);
    }
}
