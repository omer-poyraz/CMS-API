using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Entities.Models
{
    public class Module
    {
        public int ID { get; set; }
        public string? Site { get; set; }
        public ICollection<string>? Files { get; set; }
        public Dictionary<string, string>? Slug { get; set; }
        public Dictionary<string, string>? Name { get; set; }
        public ICollection<ModuleField> Fields { get; set; }
        public int? Sort { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
