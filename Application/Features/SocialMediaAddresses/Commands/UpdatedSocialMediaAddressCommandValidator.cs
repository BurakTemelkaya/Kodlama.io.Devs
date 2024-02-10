using FluentValidation;

namespace Application.Features.SocialMediaAddresses.Commands
{
    public class UpdatedSocialMediaAddressCommandValidator: AbstractValidator<UpdatedSocialMediaAddressCommand>
    {
        public UpdatedSocialMediaAddressCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.SocialMediaName).NotEmpty();
            RuleFor(x => x.SocialMediaLink).NotEmpty();
        }
    }
}
