using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Languages;
using WebApplication1.Entities;
using WebApplication1.LanguageExceptions;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController(ILanguageService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            try
            {
                //await _service.CreateAsync(dto);

                var data = _mapper.Map<Language>(dto);
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
