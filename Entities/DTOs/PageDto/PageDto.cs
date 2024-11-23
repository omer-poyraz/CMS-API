using Entities.Models;

namespace Entities.DTOs.PageDto
{
    public record PageDto
    {
        public int PageID { get; init; }
        public string? FileName { get; init; }
        public string? FilePath { get; init; }
        public string? FileFullPath { get; init; }
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? Description { get; init; }
        public string? DescriptionEN { get; init; }
        public string? Content { get; init; }
        public string? ContentEN { get; init; }
        public Header? Header { get; init; }
        public int? HeaderID { get; init; }
        public DocumentGroup? DocumentGroup { get; init; }
        public int? DocumentGroupID { get; init; }
        public Seo? Seo { get; init; }
        public int? SeoID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
