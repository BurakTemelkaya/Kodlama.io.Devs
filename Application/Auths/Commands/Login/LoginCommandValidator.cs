using FluentValidation;

namespace Application.Auths.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x=> x.UserForLoginDto.Email).NotEmpty();
            RuleFor(x=> x.UserForLoginDto.Email).EmailAddress();
            RuleFor(x=> x.UserForLoginDto.Password).NotEmpty();
            RuleFor(x=> x.UserForLoginDto.Password).MinimumLength(6);
        }
    }
}
