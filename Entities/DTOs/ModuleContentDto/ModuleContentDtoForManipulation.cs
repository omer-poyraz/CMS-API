using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.ModuleContentDto
{
    public abstract record ModuleContentDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public Dictionary<string, string>? Text { get; set; }
        public Dictionary<string, string>? Slug { get; set; }
        public int ModuleFieldId { get; init; }
        public int? Sort { get; init; }
        public string? UserId { get; init; }
    }
}
