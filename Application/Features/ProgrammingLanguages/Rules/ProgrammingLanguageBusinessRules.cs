using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entites;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            _programingLanguageRepository = programingLanguageRepository;
        }

        public async Task SomeFeatureEntityNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programingLanguageRepository.GetListAsync(x => x.Name == name);

            if (result.Items.Any()) throw new BusinessException("Programming language name exist");
        }

        public async Task SomeFeatureEntityNameCanNotBeDuplicatedWhenUpdated(int id,string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programingLanguageRepository.GetListAsync(x => x.Id != id && x.Name == name);

            if (result.Items.Any()) throw new BusinessException("Programming language name exist");
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested programming language does not exist.");
        }
    }
}
