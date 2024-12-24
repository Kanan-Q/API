using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess;
using WebApplication1.DTO.Games;
using WebApplication1.Entities;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Services.Implements
{
    public class GameService(AppDbContext _sql, IMapper _mapper) : IGameService
    {
        public async Task CreateAsync(GamesCreateDto dto)
        {
            var data = _mapper.Map<Game>(dto);
            await _sql.Games.AddAsync(data);
            await _sql.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var data = await _sql.Games.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(data != null)
            {
                _sql.Games.Remove(data);
            }
            _sql.SaveChangesAsync();
        }

        public async Task<IEnumerable<GamesGetDto>> GetAllAsync()
        {
            var data=await _sql.Games.ToListAsync();
            return _mapper.Map<IEnumerable<GamesGetDto>>(data);
        }

        public async Task UpdateAsync(GamesUpdateDto dto)
        {
            var data = await _sql.Games.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (data != null)
            {
                _mapper.Map(dto, data);
            }
            await _sql.SaveChangesAsync();
        }

    }
}
