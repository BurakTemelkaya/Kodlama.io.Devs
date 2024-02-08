using Application.Features.ProgrammingLanguages.Dtos;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class CreateProgramingLanguageCommandValidator:AbstractValidator<CreatedProgrammingLanguageDto>
    {
        public CreateProgramingLanguageCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PublicationDate).NotEmpty();
        }
    }
}
