using WebApplication1.DTO.Games;
using WebApplication1.DTO.Words;

namespace WebApplication1.Services.Abstracts
{
    public interface IGameService
    {
        Task<IEnumerable<GamesGetDto>> GetAllAsync();
        Task CreateAsync(GamesCreateDto dto);
        Task<WordForGameDto> Start(Guid id);
        Task<WordForGameDto> Fail(Guid id);
        Task<WordForGameDto> Success(Guid id);
        Task<WordForGameDto> Skip(Guid id);
        Task<GamesStatusDto> End(Guid id);

    }
}
