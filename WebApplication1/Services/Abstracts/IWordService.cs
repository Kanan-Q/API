using WebApplication1.DTO.Words;

namespace WebApplication1.Services.Abstracts
{
    public interface IWordService
    {
        Task<IEnumerable<WordsGetDto>> GetAllAsync();
        Task CreateAsync(WordsCreateDto dto);
        Task UpdateAsync(WordsUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
