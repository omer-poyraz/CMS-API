using Entities.Models;

namespace Entities.DTOs.SocialDto
{
    public record SocialDto
    {
        public int SocialID { get; init; }
        public string? FileName { get; init; }
        public string? FilePath { get; init; }
        public string? FileFullPath { get; init; }
        public string? Title { get; init; }
        public string? URL { get; init; }
        public SocialMedia? SocialMedia { get; init; }
        public int? SocialMediaID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
