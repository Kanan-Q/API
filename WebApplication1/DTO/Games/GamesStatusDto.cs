using WebApplication1.DTO.Words;
using WebApplication1.Entities;

namespace WebApplication1.DTO.Games
{
    public class GamesStatusDto
    {
        public int Success { get; set; }
        public int Fail { get; set; }
        public int Skip { get; set; }
        public int Score { get; set; }
        public Stack<WordForGameDto> Words { get; set; }
        public IEnumerable<int> UsedWordIds { get; set; }
        public int MaxSkipCount {  get; set; }

    }
}
