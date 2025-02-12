using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.LanguageDto
{
    public class LanguageDto
    {
        public int ID { get; init; }
        public string? File { get; init; }
        public string? Title { get; init; }
        public string? UserId { get; init; }
        public User? User { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
