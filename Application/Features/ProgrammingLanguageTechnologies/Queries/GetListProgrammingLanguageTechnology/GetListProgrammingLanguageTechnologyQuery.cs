using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology
{
    public class GetListProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyListModel>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programingLanguageTechnologyRepository, IMapper mapper)
            {
                _programingLanguageTechnologyRepository = programingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguageTechnology> programmingLanguageTechnologies =
                    await _programingLanguageTechnologyRepository.GetListAsync(index: request.PageRequest.Page,
                                                                               size: request.PageRequest.PageSize,
                                                                               include: a=> a.Include(p=> p.ProgrammingLanguage));

                ProgrammingLanguageTechnologyListModel mappedProgrammingLanguageTechnologiesListModel =
                    _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);

                return mappedProgrammingLanguageTechnologiesListModel;
            }
        }
    }
}
