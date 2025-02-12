using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.ModuleContentDto
{
    public class ModuleContentDto
    {
        public int ID { get; init; }
        public ICollection<string>? Files { get; init; }
        public Dictionary<string, string>? Text { get; init; }
        public Dictionary<string, string>? Slug { get; init; }
        public ModuleField? ModuleField { get; init; }
        public int ModuleFieldId { get; init; }
        public int? Sort { get; init; }
        public string? UserId { get; init; }
        public User? User { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
