using HiFiApp.Service.Abstract;
using HiFiApp.Service.Concrete;
using HiFiApp.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiFiApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiFisController : ControllerBase
    {
        private readonly IHiFiService _hiFiService;

        public HiFisController(IHiFiService hiFiService)
        {
            _hiFiService = hiFiService;
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
    }
}
