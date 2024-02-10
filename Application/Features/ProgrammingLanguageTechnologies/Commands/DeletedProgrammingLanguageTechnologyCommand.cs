using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands
{
    public class DeletedProgrammingLanguageTechnologyCommand : IRequest<DeletedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }

        public class DeletedProgrammingLanguageTechnologyCommandHandler :
            IRequestHandler<DeletedProgrammingLanguageTechnologyCommand, DeletedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologyBusinessRules _programingLanguageTechnologyBusinessRules;

            public DeletedProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programingLanguageTechnologyRepository,
                IMapper mapper, ProgrammingLanguageTechnologyBusinessRules programingLanguageTechnologyBusinessRules)
            {
                _programingLanguageTechnologyRepository = programingLanguageTechnologyRepository;
                _mapper = mapper;
                _programingLanguageTechnologyBusinessRules = programingLanguageTechnologyBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageTechnologyDto> Handle(DeletedProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var deletedProgrammingLanguageTechnology = await _programingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id);

                _programingLanguageTechnologyBusinessRules
                    .ProgrammingLanguageTechnologyShouldExistWhenRequested(deletedProgrammingLanguageTechnology);

                var result = _programingLanguageTechnologyRepository.Delete(deletedProgrammingLanguageTechnology);

                DeletedProgrammingLanguageTechnologyDto response = 
                    _mapper.Map<DeletedProgrammingLanguageTechnologyDto>(result);

                return response;
            }
        }
    }
}
