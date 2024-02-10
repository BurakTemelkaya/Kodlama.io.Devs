using FluentValidation;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands
{
    public class DeletedProgrammingLanguageTechnologyCommandValidator : AbstractValidator<DeletedProgrammingLanguageTechnologyCommand>
    {
        public DeletedProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(x=> x.Id).NotEmpty();
        }
    }
}
