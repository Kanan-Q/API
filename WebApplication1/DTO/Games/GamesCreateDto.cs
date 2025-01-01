using WebApplication1.Entities;

namespace WebApplication1.DTO.Games
{
    public class GamesCreateDto
    {
        public int BannedWordCount { get; set; }
        public int FailCount { get; set; }
        public int MaxSkipCount { get; set; }
        public int SkipCount { get; set; }
        public int Time { get; set; }
        public string LangCode { get; set; }
    }
}
