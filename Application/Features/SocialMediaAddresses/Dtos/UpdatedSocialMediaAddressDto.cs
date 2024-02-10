namespace Application.Features.SocialMediaAddresses.Dtos
{
    public class UpdatedSocialMediaAddressDto
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaLink { get; set; }
        public int UserId { get; set; }
    }
}
