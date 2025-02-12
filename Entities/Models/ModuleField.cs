using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Entities.Models
{
    public class ModuleField
    {
        public int ID { get; set; }
        public ICollection<string>? Files { get; set; }
        public Dictionary<string, string>? FieldName { get; set; }
        public Dictionary<string, string>? Slug { get; set; }
        public string? Site { get; set; }
        public string? FieldType { get; set; }
        public bool? IsRequired { get; set; }
        public int? Sort { get; set; }

        [ForeignKey("ModuleId")]
        public Module Module { get; set; }
        public int ModuleId { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ModuleField()
        {
            FieldName = new Dictionary<string, string>();
            Slug = new Dictionary<string, string>();
            Files = new List<string>();
            Sort = ID;
        }
    }
}
