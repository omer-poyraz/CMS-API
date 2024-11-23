using Entities.Models;

namespace Entities.DTOs.SeoDto
{
    public record SeoDto
    {
        public int SeoID { get; init; }
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? Description { get; init; }
        public string? DescriptionEN { get; init; }
        public string? Keywords { get; init; }
        public string? KeywordsEN { get; init; }
        public string? Author { get; init; }
        public string? AuthorEN { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
