using Entities.Models;

namespace Entities.DTOs.DocumentDto
{
    public record DocumentDto
    {
        public int DocumentID { get; init; }
        public string? FileName { get; init; }
        public string? FilePath { get; init; }
        public string? FileFullPath { get; init; }
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public DocumentGroup? DocumentGroup { get; init; }
        public int? DocumentGroupID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
