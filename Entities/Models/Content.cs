using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Entities.Models
{
    public class Content
    {
        public int ID { get; set; }
        public string? Slug { get; set; }
        public string? Site { get; set; }
        public string? Text { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        public int LanguageId { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? Postdate { get; set; }
        public DateTime? Expdate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
