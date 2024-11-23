using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Social
    {
        public int SocialID { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFullPath { get; set; }
        public string? Title { get; set; }
        public string? URL { get; set; }
        [ForeignKey("SocialMediaID")]
        public SocialMedia? SocialMedia { get; set; }
        public int? SocialMediaID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
