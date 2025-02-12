using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.ModuleDto
{
    public class ModuleDto
    {
        public int ID { get; init; }
        public ICollection<string>? Files { get; init; }
        public Dictionary<string, string> Name { get; init; }
        public Dictionary<string, string> Slug { get; init; }
        public string? Site { get; init; }
        public ICollection<ModuleField> Fields { get; init; }
        public int? Sort { get; init; }
        public string? UserId { get; init; }
        public User? User { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
