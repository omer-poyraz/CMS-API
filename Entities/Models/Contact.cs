using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string? Title { get; set; }
        public string? TitleEN { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEN { get; set; }
        public string? AddField1 { get; set; }
        public string? AddField2 { get; set; }
        public string? AddField3 { get; set; }
        public string? AddField4 { get; set; }
        public string? AddField5 { get; set; }

        [ForeignKey("SocialMediaID")]
        public SocialMedia? SocialMedia { get; set; }
        public int? SocialMediaID { get; set; }
        public ICollection<Dealer>? Dealers { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
