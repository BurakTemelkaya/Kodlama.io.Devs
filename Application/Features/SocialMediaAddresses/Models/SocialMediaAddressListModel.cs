using Application.Features.SocialMediaAddresses.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.SocialMediaAddresses.Models
{
    public class SocialMediaAddressListModel : BasePageableModel
    {
        public IList<SocialMediaAddressListDto> Items { get; set; }
    }
}
