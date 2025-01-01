using AutoMapper;
using WebApplication1.DTO.Games;
using WebApplication1.Entities;

namespace WebApplication1.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GamesGetDto>();
            CreateMap<GamesCreateDto, Game>();
            CreateMap<GamesUpdateDto, Game>();
            //CreateMap<GamesStatusDto, Game>();
        }
    }
}
