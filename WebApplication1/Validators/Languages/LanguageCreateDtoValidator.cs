using FluentValidation;
using WebApplication1.DTO.Languages;

namespace WebApplication1.Validators.Languages
{
    public class LanguageCreateDtoValidator:AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x=>x.Code).NotEmpty().WithMessage("Code bosh ola bilmez!").NotNull().WithMessage("Code null ola bilmez").Length(2).WithMessage("2 den uzun ola bilmez");
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad bosh ola bilmez!").NotNull().WithMessage("Ad null ola bilmez").MaximumLength(32).WithMessage("32 den uzun ola bilmez").MinimumLength(3).WithMessage("3-den az ola bilmez");
            RuleFor(x => x.IconUrl)
                .NotEmpty().WithMessage("Icon bosh ola bilmez!").NotNull().WithMessage("Icon null ola bilmez").MaximumLength(3000).
                WithMessage("3000 den uzun ola bilmez").Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$").WithMessage("Url Link olmalidir");
        }
    }
}
