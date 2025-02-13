using Entities.Models;

namespace Entities.DTOs.SettingsDto
{
    public class SettingsDto
    {
        public int ID { get; init; }
        public string? Site { get; init; }
        public ICollection<string>? Files { get; init; }
        public Dictionary<string, string>? Name { get; init; }
        public Dictionary<string, string>? Phone { get; init; }
        public Dictionary<string, string>? Address { get; init; }
        public Dictionary<string, string>? Fax { get; init; }
        public Dictionary<string, string>? Country { get; init; }
        public Dictionary<string, string>? City { get; init; }
        public Dictionary<string, string>? District { get; init; }
        public Module? Module { get; init; }
        public int? ModuleId { get; init; }
        public string? UserId { get; init; }
        public User? User { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
