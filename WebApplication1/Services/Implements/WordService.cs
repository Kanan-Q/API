using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess;
using WebApplication1.DTO.Words;
using WebApplication1.Entities;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Services.Implements
{
    public class WordService(AppDbContext _sql, IMapper _mapper) : IWordService
    {
        public async Task<IEnumerable<WordsGetDto>> GetAllAsync()
        {
            var data=await _sql.Words.ToListAsync();
            return _mapper.Map<IEnumerable<WordsGetDto>>(data);
        }


        public async Task CreateAsync(WordsCreateDto dto)
        {
            var data = _mapper.Map<Word>(dto);
            await _sql.Words.AddAsync(data);
            await _sql.SaveChangesAsync();
        }



        public async Task DeleteAsync(int id)
        {
            var data = await _sql.Words.Where(x => x.Id ==id).FirstOrDefaultAsync();
            if (data != null)
            {
                _sql.Games.Remove(data);
            }
            await _sql.SaveChangesAsync();
        }



        public async Task UpdateAsync(WordsUpdateDto dto)
        {
            var data = _sql.Words.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (data != null)
            {
                _mapper.Map(dto,data);
            }
            await _sql.SaveChangesAsync();
        }
    }
}
