using FluentValidation;
using WebApplication1.DTO.Games;

namespace WebApplication1.Validators.Games
{
    public class GamesCreateValidator:AbstractValidator<GamesCreateDto>
    {
        public GamesCreateValidator()
        {
            //RuleFor()
        }
    }
}
