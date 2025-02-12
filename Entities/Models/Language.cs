using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Entities.Models
{
    public class Language
    {
        public int ID { get; set; }
        public string? File { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
