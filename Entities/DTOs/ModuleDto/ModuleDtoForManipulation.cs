using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.ModuleDto
{
    public abstract record ModuleDtoForManipulation
    {
        public string? Site { get; init; }
        public ICollection<string>? Files { get; set; }
        public Dictionary<string, string> Name { get; set; }
        public Dictionary<string, string> Slug { get; set; }
        public int? Sort { get; init; }
        public string? UserId { get; init; }
    }
}
