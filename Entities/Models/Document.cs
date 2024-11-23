using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Document
    {
        public int DocumentID { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFullPath { get; set; }
        public string? Title { get; set; }
        public string? TitleEN { get; set; }
        [ForeignKey("DocumentGroupID")]
        public DocumentGroup? DocumentGroup { get; set; }
        public int? DocumentGroupID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
