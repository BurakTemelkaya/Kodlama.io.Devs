using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class DeletedProgrammingLanguageCommand:IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeletedProgrammingLanguageCommandHandler: IRequestHandler<DeletedProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programingLanguageBusinessRules;

            public DeletedProgrammingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository,
                IMapper mapper, ProgrammingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeletedProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var deletedProgrammingLanguage = await _programingLanguageRepository.GetAsync(x => x.Id == request.Id);

                _programingLanguageBusinessRules
                    .ProgrammingLanguageShouldExistWhenRequested(deletedProgrammingLanguage);

                var result = _programingLanguageRepository.Delete(deletedProgrammingLanguage);

                DeletedProgrammingLanguageDto response =
                    _mapper.Map<DeletedProgrammingLanguageDto>(result);

                return response;
            }
        }
    }
}
