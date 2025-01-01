using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess;
using WebApplication1.DTO.BannedWord;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Services.Implements
{
    public class BannedService(AppDbContext _sql, IMapper _mapper) : IBannedService
    {
        public async Task UpdateAsync(BannedUpdateDto dto)
        {
            var data = await _sql.BannedWords.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (data != null)
            {
                _mapper.Map(dto, data);
            }
            await _sql.SaveChangesAsync();
        }
    }
}
