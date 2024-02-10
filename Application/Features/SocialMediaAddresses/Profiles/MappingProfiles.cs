using Application.Features.SocialMediaAddresses.Commands;
using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.SocialMediaAddresses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entites;

namespace Application.Features.SocialMediaAddresses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMediaAddress, CreatedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, CreatedSocialMediaAddressCommand>().ReverseMap();

            CreateMap<SocialMediaAddress, UpdatedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, UpdatedSocialMediaAddressCommand>().ReverseMap();

            CreateMap<SocialMediaAddress, DeletedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, DeletedSocialMediaAddressCommand>().ReverseMap();

            CreateMap<IPaginate<SocialMediaAddress>, SocialMediaAddressListModel>().ReverseMap();
            CreateMap<SocialMediaAddress, SocialMediaAddressListDto>()
                .ForMember(c => c.UserMail, opt => opt.MapFrom(c => c.User.Email))
                .ReverseMap();

            CreateMap<SocialMediaAddress, SocialMediaAddressGetByIdDto>()
                .ForMember(c => c.UserMail, opt => opt.MapFrom(c => c.User.Email))
                .ReverseMap();
        }

    }
}
