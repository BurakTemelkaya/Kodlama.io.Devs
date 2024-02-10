using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.SocialMediaAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.SocialMediaAddresses.Commands
{
    public class DeletedSocialMediaAddressCommand : IRequest<DeletedSocialMediaAddressDto>
    {
        public int Id { get; set; }

        public class DeletedSocialMediaAddressCommandHandler : IRequestHandler<DeletedSocialMediaAddressCommand, DeletedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaAddressBusinessRules _socialMediaAddressbusinessRules;

            public DeletedSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper,
                SocialMediaAddressBusinessRules socialMediaAddressBusinessRules)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
                _socialMediaAddressbusinessRules = socialMediaAddressBusinessRules;
            }

            public async Task<DeletedSocialMediaAddressDto> Handle(DeletedSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                var deletedSocialMediaAddress = await _socialMediaAddressRepository.GetAsync(x => x.Id == request.Id);

                _socialMediaAddressbusinessRules.SocialMediaAddressShouldExistWhenRequested(deletedSocialMediaAddress);

                var result = _socialMediaAddressRepository.Delete(deletedSocialMediaAddress);

                DeletedSocialMediaAddressDto deletedSocialMediaAddressDto = _mapper.Map<DeletedSocialMediaAddressDto>(result);

                return deletedSocialMediaAddressDto;
            }
        }
    }
}
