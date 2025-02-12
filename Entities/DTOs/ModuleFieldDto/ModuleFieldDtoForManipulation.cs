using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.ModuleFieldDto
{
    public abstract record ModuleFieldDtoForManipulation
    {
        public string? Site { get; init; }
        public ICollection<string>? Files { get; set; }
        public Dictionary<string, string>? FieldName { get; set; }
        public Dictionary<string, string>? Slug { get; set; }
        public string? FieldType { get; init; }
        public bool? IsRequired { get; init; }
        public int ModuleId { get; init; }
        public int? Sort { get; init; }
        public string? UserId { get; init; }
    }
}
