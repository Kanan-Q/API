using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.DataAccess;
using WebApplication1.DTO.Games;
using WebApplication1.DTO.Words;
using WebApplication1.Entities;
using WebApplication1.Extension;
using WebApplication1.LanguageExceptions;
using WebApplication1.Services.Abstracts;

namespace WebApplication1.Services.Implements
{
    public class GameService(AppDbContext _sql, IMapper _mapper, IMemoryCache _cache) : IGameService
    {
        public async Task CreateAsync(GamesCreateDto dto)
        {
            var data = _mapper.Map<Game>(dto);
            await _sql.Games.AddAsync(data);
            await _sql.SaveChangesAsync();
        }


        public async Task<IEnumerable<GamesGetDto>> GetAllAsync()
        {
            var data = await _sql.Games.ToListAsync();
            return _mapper.Map<IEnumerable<GamesGetDto>>(data);
        }

        public async Task<WordForGameDto> Start(Guid id)
        {
            var game = await _sql.Games.FindAsync(id);
            if (game == null || game.Score == null)
            {
                throw new StartGameException();
            }
            //IQueryable<Word> query = _sql.Words.Where(x => x.LangCode = game.LangCode);
            var words = await _sql.Words.Where(x => x.LangCode == game.LangCode).Select(x => new WordForGameDto
            {
                Id = x.Id,
                Word = x.Text,
                BannedWords = x.BannedWords.Select(y => y.Text)
            }).Random(await _sql.Words.Where(x => x.LangCode == game.LangCode).CountAsync()).Take(20).ToListAsync();

            var wordStack = new Stack<WordForGameDto>(words);
            WordForGameDto currentWord = wordStack.Pop();
            GamesStatusDto status = new GamesStatusDto()
            {
                Fail = 0,
                Skip = 0,
                Success = 0,
                Words = wordStack,
                UsedWordIds = words.Select(x => x.Id)
            };
            _cache.Set(id, status, DateTime.Now.AddMinutes(game.Time));
            return currentWord;
        }

        public async Task<WordForGameDto> Fail(Guid id)
        {
            var status = _getCurrentGame(id);
            var currentWord = status.Words.Pop();
            status.Fail++;
            status.Skip--;
            _cache.Set(id, status);
            return currentWord;
        }

        public async Task<WordForGameDto> Success(Guid id)
        {
            var status = _getCurrentGame(id);
            status.Success++;
            status.Score++;
            var currentWord = status.Words.Pop();
            _cache.Set(id, status);
            return currentWord;
        }

        public async Task<WordForGameDto> Skip(Guid id)
        {
            var status = _getCurrentGame(id);
            if (status.Skip <= status.MaxSkipCount)
            {
                var currentWord = status.Words.Pop();
                status.Skip++;
                _cache.Set(id, status, DateTime.Now.AddMinutes(3));
                return currentWord;
            }
            return null;
        }

        public async Task<GamesStatusDto> End(Guid id)
        {
            var status = _getCurrentGame(id);
            _cache.Remove(id);
            return new GamesStatusDto
            {
                Score = status.Score,
                Fail = status.Fail,
                Skip = status.Skip,
                Success = status.Success
            };
        }
        GamesStatusDto _getCurrentGame(Guid id)
        {
            var result = _cache.Get<GamesStatusDto>(id);
            if (result == null) throw new Exception();
            return result;
        }
    }
}
