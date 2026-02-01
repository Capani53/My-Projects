using System.Text.Json;
using HiFiApp.Service.Abstract;
using HiFiApp.Shared.Dtos;
using HiFiApp.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiFiApp.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HiFiController : ControllerBase
    {
        private readonly IHiFiService _hiFiService;
        private readonly IImageHelper _imageHelper;

        public HiFiController(IHiFiService hiFiService, IImageHelper imageHelper)
        {
            _hiFiService=hiFiService;
            _imageHelper=imageHelper;
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
            if(!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
                
        [HttpGet("homehiFis")]
        public async Task<IActionResult> GetHomeHiFi()
        {
            var response = await _hiFiService.GetHomeHiFiAsync();
            if(!response.IsSucceeded)
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
            var response = await _hiFiService.GetHiFiByCategoryIdAsync(categoryId);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
                
        [HttpGet("active/{isActive}")]
        public async Task<IActionResult> GetActiveHiFi(bool isActive)
        {
            var response = await _hiFiService.GetActiveHiFiAsync(isActive);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("getallhiFis")]
        public async Task<IActionResult> GetAllHiFi()
        {
            var response = await _hiFiService.GetHiFiWithCategoriesAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }        

        [HttpPost("addimage")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            var response = await _imageHelper.Upload(file,"hiFis");
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
