using Application.OperationClaims.Commands.UpdateOperationClaim;
using Application.OperationClaims.Dtos;
using Application.OperationClaims.Models;
using Application.OperationClaims.Commands.CreateOperationClaim;
using Application.OperationClaims.Commands.DeleteOperationClaim;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.OperationClaims.Profiles
{
    public class OperationClaimMappingProfiles : Profile

    {
        public OperationClaimMappingProfiles()
        {
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
        }
    }
}
