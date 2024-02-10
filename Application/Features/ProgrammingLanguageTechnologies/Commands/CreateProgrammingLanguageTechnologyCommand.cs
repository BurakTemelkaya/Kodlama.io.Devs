using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class CreateProgrammingLanguageTechnologyCommand : IRequest<CreateProgrammingLanguageTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommand, CreateProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologyBusinessRules _programingLanguageTechnologyBusinessRules;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageTechnologyRepository programingLanguageTechnologyRepository,
                IMapper mapper, ProgrammingLanguageTechnologyBusinessRules programingLanguageTechnologyBusinessRules)
            {
                _programingLanguageTechnologyRepository = programingLanguageTechnologyRepository;
                _mapper = mapper;
                _programingLanguageTechnologyBusinessRules = programingLanguageTechnologyBusinessRules;
            }

            public async Task<CreateProgrammingLanguageTechnologyDto> Handle(CreateProgrammingLanguageTechnologyCommand request,
                CancellationToken cancellationToken)
            {
                await _programingLanguageTechnologyBusinessRules.SomeFeatureEntityNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguageTechnology mappedProgrammingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
                ProgrammingLanguageTechnology createdProgrammingLanguageTechnology = await _programingLanguageTechnologyRepository.AddAsync(mappedProgrammingLanguageTechnology);
                CreateProgrammingLanguageTechnologyDto createdProgrammingLanguageTechnologyDto = _mapper.Map<CreateProgrammingLanguageTechnologyDto>(createdProgrammingLanguageTechnology);

                return createdProgrammingLanguageTechnologyDto;
            }
        }
    }
}
