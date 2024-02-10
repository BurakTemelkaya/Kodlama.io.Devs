using FluentValidation;

namespace Application.Auths.Commands.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x=> x.UserForRegisterDto.Email).NotEmpty();
            RuleFor(x=> x.UserForRegisterDto.Email).EmailAddress();
            RuleFor(x=> x.UserForRegisterDto.Password).NotEmpty();
            RuleFor(x=> x.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(x=> x.UserForRegisterDto.FirstName).MinimumLength(3);
            RuleFor(x=> x.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(x=> x.UserForRegisterDto.LastName).MinimumLength(3);
        }
    }
}
