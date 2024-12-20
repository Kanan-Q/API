using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Languages;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return StatusCode(201,"Created");
        }
        [HttpPut]
        public async Task<IActionResult> Update(LanguageUpdateDto dto)
        {
            if (dto is null) return StatusCode(400, "BadRequest");
            await _service.UpdateAsync(dto);
            return StatusCode(200, "Updated");
        }
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            if (code is null) return StatusCode(400, "BadRequest");
            await _service.DeleteAsync(code);
            return StatusCode(200, "Deleted");
        }
    }
}
