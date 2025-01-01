using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using WebApplication1.DTO.Games;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service, IMapper _mapper, IMemoryCache _cache) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GamesCreateDto>>(data);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(GamesCreateDto dto)
        {
            var data = _mapper.Map<GamesCreateDto>(dto);
            await _service.CreateAsync(data);
            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(_cache.Get(key));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Set(string key, string value)
        {
            return Ok(_cache.Set(key, value, DateTime.Now.AddSeconds(20)));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Start(Guid id)
        {
            return Ok(await _service.Start(id));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Skip(Guid id)
        {
            return Ok(await _service.Skip(id));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Success(Guid id)
        {
            return Ok(await _service.Success(id));
        }

    }
}
