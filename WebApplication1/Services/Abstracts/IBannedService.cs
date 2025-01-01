using WebApplication1.DTO.BannedWord;
using WebApplication1.DTO.Games;

namespace WebApplication1.Services.Abstracts
{
    public interface IBannedService
    {
        Task UpdateAsync(BannedUpdateDto dto);
    }
}
