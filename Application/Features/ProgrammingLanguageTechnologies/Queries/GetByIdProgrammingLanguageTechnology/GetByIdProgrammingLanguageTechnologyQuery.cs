using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology
{
    public class GetByIdProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguageTechnologyQueryHandler :
            IRequestHandler<GetByIdProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyGetByIdDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

            public GetByIdProgrammingLanguageTechnologyQueryHandler(
                IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper,
                ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
            }

            public async Task<ProgrammingLanguageTechnologyGetByIdDto> Handle(GetByIdProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology? programmingLanguageTechnology =
                    await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id,
                    a => a.Include(p => p.ProgrammingLanguage));

                _programmingLanguageTechnologyBusinessRules
                    .ProgrammingLanguageTechnologyShouldExistWhenRequested(programmingLanguageTechnology);

                ProgrammingLanguageTechnologyGetByIdDto mappedProgrammingLanguageTechnologyModel =
                    _mapper.Map<ProgrammingLanguageTechnologyGetByIdDto>(programmingLanguageTechnology);

                return mappedProgrammingLanguageTechnologyModel;
            }
        }
    }
}
