using Application.Features.ProgrammingLanguages.Dtos;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class UpdateProgramingLanguageCommandValidator : AbstractValidator<UpdatedProgrammingLanguageDto>
    {
        public UpdateProgramingLanguageCommandValidator()
        {
            RuleFor(x=> x.Name).NotEmpty();
            RuleFor(x=> x.PublicationDate).NotEmpty();
        }
    }
}
