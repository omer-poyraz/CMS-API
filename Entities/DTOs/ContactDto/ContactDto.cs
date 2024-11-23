using Entities.Models;

namespace Entities.DTOs.ContactDto
{
    public record ContactDto
    {
        public int ContactID { get; init; }
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? Description { get; init; }
        public string? DescriptionEN { get; init; }
        public string? AddField1 { get; init; }
        public string? AddField2 { get; init; }
        public string? AddField3 { get; init; }
        public string? AddField4 { get; init; }
        public string? AddField5 { get; init; }
        public SocialMedia? SocialMedia { get; init; }
        public int? SocialMediaID { get; init; }
        public ICollection<Dealer>? Dealers { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
