using FluentValidation;

namespace Application.Features.SocialMediaAddresses.Commands
{
    public class CreatedSocialMediaAddressCommandValidator:AbstractValidator<CreatedSocialMediaAddressCommand>
    {
        public CreatedSocialMediaAddressCommandValidator()
        {
            RuleFor(x=> x.SocialMediaName).NotEmpty();
            RuleFor(x=> x.SocialMediaLink).NotEmpty();
            RuleFor(x=> x.UserId).NotEmpty();
        }
    }
}
