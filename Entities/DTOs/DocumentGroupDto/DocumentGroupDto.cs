using Entities.Models;

namespace Entities.DTOs.DocumentGroupDto
{
    public record DocumentGroupDto
    {
        public int DocumentGroupID { get; init; }
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? Description { get; init; }
        public string? DescriptionEN { get; init; }
        public ICollection<Document>? Documents { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
