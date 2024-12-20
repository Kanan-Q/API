using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess;
using WebApplication1.DTO.Languages;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Services.Implements
{
    public class LanguageService(AppDbContext _sql) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _sql.Languages.AddAsync(new Entities.Language
            {
                Name = dto.Name,
                Code = dto.Code,
                Icon = dto.Icon,

            });
            await _sql.SaveChangesAsync();
        }


        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await _sql.Languages.Select(x => new LanguageGetDto
            {
                Name = x.Name,
                Code = x.Code,
                Icon = x.Icon
            }).ToListAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var data = await _sql.Languages.Where(x => x.Code == code).FirstOrDefaultAsync();

            if (data != null)
            {
                _sql.Languages.Remove(data);
            }
            await _sql.SaveChangesAsync();
        }

        public async Task UpdateAsync(LanguageUpdateDto dto)
        {
            var data = await _sql.Languages.Where(x => x.Code == dto.Code).FirstOrDefaultAsync();

            if (data != null)
            {
                data.Name = dto.Name;
                data.Code = dto.Code;
                data.Icon = dto.Icon;
            }
            await _sql.SaveChangesAsync();
        }
    }
}
