using FluentValidation;

namespace Application.Features.SocialMediaAddresses.Commands
{
    public class DeletedSocialMediaAddressCommandValidator:AbstractValidator<DeletedSocialMediaAddressCommand>
    {
        public DeletedSocialMediaAddressCommandValidator()
        {
            RuleFor(x=> x.Id).NotEmpty();
        }
    }
}
