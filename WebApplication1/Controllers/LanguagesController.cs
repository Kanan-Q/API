using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Languages;
using WebApplication1.Entities;
using WebApplication1.LanguageExceptions;
using WebApplication1.Services.Abstracts;
using WebApplication1.Services.Implements;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController(ILanguageService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAllAsync();
            var result = _mapper.Map<IEnumerable<LanguageGetDto>>(data);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            try
            {
                var data = _mapper.Map<LanguageCreateDto>(dto);
                await _service.CreateAsync(data);
                return StatusCode(201, "Created");
            }
            catch (Exception ex)
            {
                if (ex is IBaseException bx)
                {
                    return StatusCode(bx.StatusCode, new
                    {
                        Message = bx.ErrorMessage,
                        Code = bx.StatusCode,
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        ex.Message
                    });
                }
            }

        }
        [HttpPut]
        public async Task<IActionResult> Update(LanguageUpdateDto dto)
        {
            if (dto is null) return StatusCode(400, "BadRequest");
            var data = _mapper.Map<LanguageUpdateDto>(dto);
            await _service.UpdateAsync(data);
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
