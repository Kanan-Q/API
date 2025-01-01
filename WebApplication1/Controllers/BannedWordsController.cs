using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.DTO.BannedWord;
using WebApplication1.DTO.Languages;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordsController(IBannedService _service, IMapper _mapper) : ControllerBase
    {
        [HttpPut]
        public async Task<IActionResult> Update(BannedUpdateDto dto)
        {
            if (dto is null) return StatusCode(400, "BadRequest");
            var data = _mapper.Map<BannedUpdateDto>(dto);
            await _service.UpdateAsync(data);
            return StatusCode(200, "Updated");
        }
    }
}
