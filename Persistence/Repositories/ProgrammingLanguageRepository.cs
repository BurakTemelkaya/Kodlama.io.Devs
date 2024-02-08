using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entites;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgramingLanguageRepository
    {
        public ProgrammingLanguageRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
