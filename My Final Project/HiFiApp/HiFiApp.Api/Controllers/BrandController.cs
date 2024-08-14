using HiFiApp.Service.Abstract;
using HiFiApp.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HiFiApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IImageHelper _imageHelper;

        public BrandController(IBrandService brandService, IImageHelper imageHelper)
        {
            _brandService=brandService;
            _imageHelper=imageHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _brandService.GetAllAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }
        [HttpPost("addimage")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            var response = await _imageHelper.Upload(file, "brands");
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
