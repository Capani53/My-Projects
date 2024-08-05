using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HiFiAppClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
