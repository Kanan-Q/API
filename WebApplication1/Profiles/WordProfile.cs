using AutoMapper;
using WebApplication1.DTO.Words;
using WebApplication1.Entities;

namespace WebApplication1.Profiles
{
    public class WordProfile:Profile
    {
        public WordProfile()
        {
            CreateMap<Word,WordsGetDto>();
            CreateMap<WordsCreateDto, Word>();
            CreateMap<WordsUpdateDto, Word>();
        }
    }
}
