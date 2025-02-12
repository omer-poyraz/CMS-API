using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.ModuleFieldDto
{
    public class ModuleFieldDto
    {
        public int ID { get; init; }
        public string? Site { get; init; }
        public ICollection<string>? Files { get; init; }
        public Dictionary<string, string>? FieldName { get; init; }
        public Dictionary<string, string>? Slug { get; init; }
        public string? FieldType { get; init; }
        public bool? IsRequired { get; init; }
        public int? Sort { get; init; }
        public Module Module { get; init; }
        public int ModuleId { get; init; }
        public string? UserId { get; init; }
        public User? User { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
