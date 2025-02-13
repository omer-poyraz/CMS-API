using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Entities.Models
{
    public class ModuleContent
    {
        public int ID { get; set; }
        public ICollection<string>? Files { get; set; }
        public Dictionary<string, string>? Text { get; set; }
        public Dictionary<string, string>? Slug { get; set; }

        [ForeignKey("ModuleFieldId")]
        public ModuleField? ModuleField { get; set; }
        public int ModuleFieldId { get; set; }
        public int? Sort { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
