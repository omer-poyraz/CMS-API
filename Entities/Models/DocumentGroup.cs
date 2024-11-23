using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class DocumentGroup
    {
        public int DocumentGroupID { get; set; }
        public string? Title { get; set; }
        public string? TitleEN { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEN { get; set; }
        public ICollection<Document>? Documents { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
