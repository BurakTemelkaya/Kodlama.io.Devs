using Core.Persistence.Repositories;
using Domain.Entites;

namespace Application.Services.Repositories
{
    public interface ISocialMediaAddressRepository : IAsyncRepository<SocialMediaAddress>, IRepository<SocialMediaAddress>
    {
    }
}
