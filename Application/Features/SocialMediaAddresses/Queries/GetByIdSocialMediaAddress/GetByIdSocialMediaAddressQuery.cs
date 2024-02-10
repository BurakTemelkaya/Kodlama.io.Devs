using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.SocialMediaAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SocialMediaAddresses.Queries.GetByIdSocialMediaAddress
{
    public class GetByIdSocialMediaAddressQuery : IRequest<SocialMediaAddressGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdSocialMediaAddressQueryHandle : IRequestHandler<GetByIdSocialMediaAddressQuery, SocialMediaAddressGetByIdDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaAddressBusinessRules _socialMediaAddressBusinessRules;

            public GetByIdSocialMediaAddressQueryHandle(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper,
                SocialMediaAddressBusinessRules socialMediaAddressBusinessRules)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
                _socialMediaAddressBusinessRules = socialMediaAddressBusinessRules;
            }

            public async Task<SocialMediaAddressGetByIdDto> Handle(GetByIdSocialMediaAddressQuery request, CancellationToken cancellationToken)
            {
                SocialMediaAddress? socialMediaAddress = await _socialMediaAddressRepository.GetAsync(x => x.Id == request.Id, c => c.Include(x => x.User));

                _socialMediaAddressBusinessRules.SocialMediaAddressShouldExistWhenRequested(socialMediaAddress);

                SocialMediaAddressGetByIdDto socialMediaAddressGetByIdDto = _mapper.Map<SocialMediaAddressGetByIdDto>(socialMediaAddress);

                return socialMediaAddressGetByIdDto;
            }
        }
    }
}
