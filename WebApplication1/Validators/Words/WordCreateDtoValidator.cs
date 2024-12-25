using FluentValidation;
using WebApplication1.DTO.Words;

namespace WebApplication1.Validators.Words
{
    public class WordCreateDtoValidator:AbstractValidator<WordsCreateDto>
    {
        public WordCreateDtoValidator()
        {
            RuleForEach(x => x.BannedWords).MinimumLength(2);
            RuleFor(x => x.BannedWords).Must(x => x.Count == 6);
            RuleFor(x=>x.Text).NotEmpty().WithMessage("Bosh ola bilmez").NotNull().WithMessage("Null ola bilmez").MinimumLength(2).WithMessage("2 den kicik ola bilmez").MaximumLength(50).WithMessage("50 den boyuk ola bilmez");
            RuleFor(x => x.LangCode).NotEmpty().WithMessage("Bosh ola bilmez").NotNull().WithMessage("Null ola bilmez").Length(2);
        }
    }
}
