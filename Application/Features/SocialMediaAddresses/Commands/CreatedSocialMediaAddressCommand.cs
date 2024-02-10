using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Features.SocialMediaAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.SocialMediaAddresses.Commands
{
    public class CreatedSocialMediaAddressCommand : IRequest<CreatedSocialMediaAddressDto>
    {
        public string SocialMediaName { get; set; }
        public string SocialMediaLink { get; set; }
        public int UserId { get; set; }

        public class CreatedSocialMediaAddressCommandHandler : IRequestHandler<CreatedSocialMediaAddressCommand, CreatedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public CreatedSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSocialMediaAddressDto> Handle(CreatedSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAddress mappedSocialMediaAddress = _mapper.Map<SocialMediaAddress>(request);
                SocialMediaAddress createdSocialMediaAddress = await _socialMediaAddressRepository.AddAsync(mappedSocialMediaAddress);
                CreatedSocialMediaAddressDto createdSocialMediaAddressDto = _mapper.Map<CreatedSocialMediaAddressDto>(createdSocialMediaAddress);

                return createdSocialMediaAddressDto;
            }
        }
    }
}
