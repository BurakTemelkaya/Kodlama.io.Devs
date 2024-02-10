using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class UpdatedProgrammingLanguageTechnologyCommand : IRequest<UpdateProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class UpdatedProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdatedProgrammingLanguageTechnologyCommand, UpdateProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologyBusinessRules _programingLanguageTechnologyBusinessRules;

            public UpdatedProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programingLanguageTechnologyRepository,
                IMapper mapper, ProgrammingLanguageTechnologyBusinessRules programingLanguageTechnologyBusinessRules)
            {
                _programingLanguageTechnologyRepository = programingLanguageTechnologyRepository;
                _mapper = mapper;
                _programingLanguageTechnologyBusinessRules = programingLanguageTechnologyBusinessRules;
            }

            public async Task<UpdateProgrammingLanguageTechnologyDto> Handle(UpdatedProgrammingLanguageTechnologyCommand request,
                CancellationToken cancellationToken)
            {
                await _programingLanguageTechnologyBusinessRules.SomeFeatureEntityNameCanNotBeDuplicatedWhenUpdated(request.Id, request.Name);

                ProgrammingLanguageTechnology mappedProgrammingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
                ProgrammingLanguageTechnology updatedProgrammingLanguageTechnology = await _programingLanguageTechnologyRepository.UpdateAsync(mappedProgrammingLanguageTechnology);
                UpdateProgrammingLanguageTechnologyDto updatedProgrammingLanguageTechnologyDto = _mapper.Map<UpdateProgrammingLanguageTechnologyDto>(updatedProgrammingLanguageTechnology);

                return updatedProgrammingLanguageTechnologyDto;
            }
        }
    }
}
