using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entites
{
    public class SocialMediaAddress : Entity
    {
        public string SocialMediaName { get; set; }
        public string SocialMediaLink { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public SocialMediaAddress()
        {
            
        }

        public SocialMediaAddress(int id, string socialMediaName, string socialMediaLink, int userId)
        {
            Id = id;
            SocialMediaName = socialMediaName;
            SocialMediaLink = socialMediaLink;
            UserId = userId;
        }
    }
}
