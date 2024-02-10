using Application.Features.SocialMediaAddresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SocialMediaAddresses.Queries.GetListSocialMediaAddress
{
    public class GetListSocialMediaAddressQuery : IRequest<SocialMediaAddressListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSocialMediaAddressQueryHandler : IRequestHandler<GetListSocialMediaAddressQuery, SocialMediaAddressListModel>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public GetListSocialMediaAddressQueryHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaAddressListModel> Handle(GetListSocialMediaAddressQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMediaAddress> socialMediaAdresses = await _socialMediaAddressRepository.GetListAsync(index: request.PageRequest.Page,
                                                                                                                      size: request.PageRequest.PageSize,
                                                                                                                      include: c => c.Include(x => x.User));
                SocialMediaAddressListModel mappedSocialMediaAddressListModel = _mapper.Map<SocialMediaAddressListModel>(socialMediaAdresses);

                return mappedSocialMediaAddressListModel;
            }
        }
    }
}
