using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entites;

namespace Application.Features.SocialMediaAddresses.Rules
{
    public class SocialMediaAddressBusinessRules
    {
        private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;

        public SocialMediaAddressBusinessRules(ISocialMediaAddressRepository socialMediaAddressRepository)
        {
            _socialMediaAddressRepository = socialMediaAddressRepository;
        }

        public void SocialMediaAddressShouldExistWhenRequested(SocialMediaAddress? socialMediaAddresses)
        {
            if(socialMediaAddresses  == null)
            {
                throw new BusinessException("Requested social media address does not exist.");
            }
        }
    }
}
