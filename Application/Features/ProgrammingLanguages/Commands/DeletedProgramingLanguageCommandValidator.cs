using Application.Features.ProgrammingLanguages.Dtos;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class DeletedProgramingLanguageCommandValidator:AbstractValidator<DeletedProgrammingLanguageDto>
    {
        public DeletedProgramingLanguageCommandValidator()
        {
            RuleFor(x=> x.Id).NotEmpty();
        }
    }
}
