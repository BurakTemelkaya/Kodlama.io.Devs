using Application.Features.ProgrammingLanguages.Dtos;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class UpdateProgramingLanguageTechnologyCommandValidator : AbstractValidator<UpdatedProgrammingLanguageTechnologyCommand>
    {
        public UpdateProgramingLanguageTechnologyCommandValidator()
        {
            RuleFor(x=> x.Name).NotEmpty();
        }
    }
}
