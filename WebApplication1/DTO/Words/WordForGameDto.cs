﻿namespace WebApplication1.DTO.Words
{
    public class WordForGameDto
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public IEnumerable<string> BannedWords { get; set; }
    }
}