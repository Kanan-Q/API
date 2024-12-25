using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebApplication1.DTO.Games;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data=await _service.GetAllAsync();
            var result=_mapper.Map<IEnumerable<GamesCreateDto>>(data);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(GamesCreateDto dto)
        {
            var data=_mapper.Map<GamesCreateDto>(dto);
            await _service.CreateAsync(data);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GamesUpdateDto dto)
        {
            var data=_mapper.Map<GamesUpdateDto>(dto);
            await _service.UpdateAsync(data);
            return Ok(data);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
