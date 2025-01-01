using AutoMapper;
using WebApplication1.DTO.BannedWord;
using WebApplication1.Entities;

namespace WebApplication1.Profiles
{
    public class BannedProfile:Profile
    {
        public BannedProfile()
        {
            CreateMap<BannedUpdateDto,BannedWord>();
        }
    }
}
