using System.Collections;
using WebApplication1.DTO.Languages;

namespace WebApplication1.Services.Abstracts
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task CreateAsync(LanguageCreateDto dto);
        Task UpdateAsync(LanguageUpdateDto dto);
        Task DeleteAsync(string code);
    }

}
