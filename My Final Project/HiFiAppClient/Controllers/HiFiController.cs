using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HiFiAppClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HiFiAppClient.Controllers
{
    public class HiFiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OldDetails(int id)
        {
            ViewBag.HiFiId=id;
            var hiFi = new{
                Id=id,
                HiFiName="Samsung",
                Properties="Soundbar",
                IsActive=true,
            };
            ViewBag.HiFiObject= hiFi;
            return View();
        }
        public IActionResult Details(int id)
        {
            var hiFi = new HiFiViewModel{
                Id=id,
                Name="Samsung",
                Properties="Home Teathre",
                ImageUrl="Samsung.png",
                Price=245,
                Stock=58,
                Categories=[
                new CategoryViewModel{
                    Id=1,
                    Name="Home Teathre"
                    },
                    new CategoryViewModel{
                    Id=2,
                    Name="Soundbar"
                    }
                    ]
            };
            return View(hiFi);
        }
    }
}