using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Words;
using WebApplication1.Entities;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAllAsync();
            var result = _mapper.Map<IEnumerable<WordsGetDto>>(data);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(WordsCreateDto dto)
        {
            var data = _mapper.Map<WordsCreateDto>(dto);
            await _service.CreateAsync(data);
            return Ok(data);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMany(List<WordsCreateDto> dto)
        {
            foreach (var item in dto)
            {
                var data = _mapper.Map<WordsCreateDto>(dto);
                await _service.CreateAsync(data);
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(WordsUpdateDto dto)
        {
            var data = _mapper.Map<WordsUpdateDto>(dto);
            await _service.UpdateAsync(data);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }


    }
}
