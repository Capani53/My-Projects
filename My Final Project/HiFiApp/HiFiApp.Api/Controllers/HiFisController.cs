using System.Text.Json;
using HiFiApp.Service.Abstract;
using HiFiApp.Service.Concrete;
using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiFiApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiFisController : ControllerBase
    {
        private readonly IHiFiService _hiFiService;
        private readonly IImageHelper _imageHelper;

        public HiFisController(IHiFiService hiFiService, IImageHelper imageHelper)
        {
            _hiFiService = hiFiService;
            _imageHelper = imageHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddHiFiDto addHiFiDto)
        {
            var response = await _hiFiService.AddAsync(addHiFiDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _hiFiService.GetAllAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("homehifis")]
        public async Task<IActionResult> GetHomeHiFis()
        {
            var response = await _hiFiService.GetHomeHiFisAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _hiFiService.GetByIdAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditHiFiDto editHiFiDto)
        {
            var response = await _hiFiService.UpdateAsync(editHiFiDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _hiFiService.DeleteAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("bycategory/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var response = await _hiFiService.GetHiFisByCategoryIdAsync(categoryId);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("active/{isActive}")]
        public async Task<IActionResult> GetActiveHiFis(bool isActive)
        {
            var response = await _hiFiService.GetActiveHiFisAsync(isActive);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpPost("addimage")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            var response = await _imageHelper.Upload(file);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
