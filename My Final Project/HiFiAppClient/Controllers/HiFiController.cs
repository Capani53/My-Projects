using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HiFiAppClient.Models;
using HiFiAppClient.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HiFiAppClient.Controllers
{
    public class HiFiController : Controller
    {
        public IActionResult Index()
        {
            List<HiFiViewModel>hiFis = DataRepository.GetHiFis();
            return View(hiFis);
        }
        public IActionResult Update(int id)
        {
            HiFiViewModel updatedHiFi = DataRepository.GetHiFi(id);
            return View(updatedHiFi);
        }
        [HttpPost]
        public IActionResult Update(HiFiViewModel hiFiViewModel)
        {
            return View();
        }
    }
}