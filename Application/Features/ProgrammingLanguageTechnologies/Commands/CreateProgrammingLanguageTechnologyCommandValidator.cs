using Application.Features.ProgrammingLanguages.Dtos;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class CreateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<CreateProgrammingLanguageTechnologyCommand>
    {
        public CreateProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
