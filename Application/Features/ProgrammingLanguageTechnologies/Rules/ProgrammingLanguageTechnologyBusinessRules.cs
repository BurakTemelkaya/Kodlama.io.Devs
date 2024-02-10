using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Rules
{
    public class ProgrammingLanguageTechnologyBusinessRules
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

        public ProgrammingLanguageTechnologyBusinessRules(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
        }

        public async Task SomeFeatureEntityNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguageTechnology> result = await _programmingLanguageTechnologyRepository.GetListAsync(x => x.Name == name);

            if (result.Items.Any()) throw new BusinessException("Programming language technology name exist");
        }

        public async Task SomeFeatureEntityNameCanNotBeDuplicatedWhenUpdated(int id, string name)
        {
            IPaginate<ProgrammingLanguageTechnology> result = await _programmingLanguageTechnologyRepository.GetListAsync(x => x.Id != id && x.Name == name);

            if (result.Items.Any()) throw new BusinessException("Programming language technology name exist");
        }
        public void ProgrammingLanguageTechnologyShouldExistWhenRequested(ProgrammingLanguageTechnology programmingLanguageTechnology)
        {
            if (programmingLanguageTechnology == null) throw new BusinessException("Requested programming language technology does not exist.");
        }
    }
}
