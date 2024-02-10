using Application.Features.SocialMediaAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.SocialMediaAddresses.Commands
{
    public class UpdatedSocialMediaAddressCommand : IRequest<UpdatedSocialMediaAddressDto>
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaLink { get; set; }
        public int UserId { get; set; }

        public class UpdatedSocialMediaAddressCommandHandler : IRequestHandler<UpdatedSocialMediaAddressCommand, UpdatedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public UpdatedSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSocialMediaAddressDto> Handle(UpdatedSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAddress mappedSocialMediaAddress = _mapper.Map<SocialMediaAddress>(request);
                SocialMediaAddress updatedSocialMediaAddress = await _socialMediaAddressRepository.UpdateAsync(mappedSocialMediaAddress);
                UpdatedSocialMediaAddressDto updatedSocialMediaAddressDto = _mapper.Map<UpdatedSocialMediaAddressDto>(updatedSocialMediaAddress);

                return updatedSocialMediaAddressDto;
            }
        }
    }
}
