using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess;
using WebApplication1.DTO.Languages;
using WebApplication1.Entities;
using WebApplication1.LanguageExceptions;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Services.Implements
{
    public class LanguageService(AppDbContext _sql, IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _sql.Languages.AnyAsync(x => x.Code == dto.Code))
            {
                throw new LanguageExistException();
            }
            await _sql.Languages.AddAsync(_mapper.Map<Language>(dto));
            //    new Entities.Language
            //{
            //    Name = dto.Name,
            //    Code = dto.Code,
            //    Icon = dto.IconUrl,

            //}
            await _sql.SaveChangesAsync();
        }


        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            //return await _sql.Languages.Select(x => new LanguageGetDto
            //{
            //    Name = x.Name,
            //    Code = x.Code,
            //    Icon = x.Icon
            //}).ToListAsync();
            var data = await _sql.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(data);
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
