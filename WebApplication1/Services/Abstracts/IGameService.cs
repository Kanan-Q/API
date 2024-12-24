using WebApplication1.DTO.Games;

namespace WebApplication1.Services.Abstracts
{
    public interface IGameService
    {
        Task<IEnumerable<GamesGetDto>> GetAllAsync();
        Task CreateAsync(GamesCreateDto dto);
        Task UpdateAsync (GamesUpdateDto dto);
        Task DeleteAsync (Guid id);
    }
}
