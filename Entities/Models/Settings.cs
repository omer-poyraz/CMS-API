using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Settings
    {
        public int ID { get; set; }
        public string? Site { get; set; }
        public ICollection<string>? Files { get; set; }
        public Dictionary<string, string>? Name { get; set; }
        public Dictionary<string, string>? Phone { get; set; }
        public Dictionary<string, string>? Address { get; set; }
        public Dictionary<string, string>? Country { get; set; }
        public Dictionary<string, string>? City { get; set; }
        public Dictionary<string, string>? District { get; set; }
        public Dictionary<string, string>? Fax { get; set; }
        [ForeignKey("ModuleId")]
        public Module? Module { get; set; }
        public int? ModuleId { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
