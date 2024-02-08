using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class UpdatedProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PublicationDate { get; set; }

        public class UpdatedProgrammingLanguageCommandHandler : IRequestHandler<UpdatedProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programingLanguageBusinessRules;

            public UpdatedProgrammingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdatedProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBusinessRules.SomeFeatureEntityNameCanNotBeDuplicatedWhenUpdated(request.Id, request.Name);

                ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage updatedProgrammingLanguage = await _programingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);
                UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);

                return updatedProgrammingLanguageDto;
            }
        }
    }
}
