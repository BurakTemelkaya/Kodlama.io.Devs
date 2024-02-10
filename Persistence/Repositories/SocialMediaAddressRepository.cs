using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entites;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SocialMediaAddressRepository : EfRepositoryBase<SocialMediaAddress, BaseDbContext>, ISocialMediaAddressRepository
    {
        public SocialMediaAddressRepository(BaseDbContext context) : base(context)
        {
            
        }
    }
}
