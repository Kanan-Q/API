namespace WebApplication1.DTO.Words
{
    public class WordsCreateDto
    {
        public string Text { get; set; }
        public string LangCode { get; set; }
        public HashSet<string> BannedWords { get; set; }
    }
}
