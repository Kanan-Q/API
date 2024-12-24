using AutoMapper;
using WebApplication1.DTO.Languages;
using WebApplication1.Entities;

namespace WebApplication1.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>().ForMember(l => l.Icon, lcd => lcd.MapFrom(x => x.IconUrl));
            //CreateMap<Language,LanguageGetDto>().ForMember(l => l.Icon, lcd => lcd.MapFrom(x => x.IconUrl));
        }
    }
}
