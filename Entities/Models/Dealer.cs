using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Dealer
    {
        public int DealerID { get; set; }
        public string? Title { get; set; }
        public string? TitleEN { get; set; }
        public string? City { get; set; }
        public string? CityEN { get; set; }
        public string? Address { get; set; }
        public string? AddressEN { get; set; }
        public string? Phone { get; set; }
        public string? Phone2 { get; set; }
        public string? Mail { get; set; }
        public string? Mail2 { get; set; }
        public string? Fax { get; set; }
        public string? Fax2 { get; set; }
        public string? URL { get; set; }
        public string? AddField1 { get; set; }
        public string? AddField2 { get; set; }
        public string? AddField3 { get; set; }
        public string? AddField4 { get; set; }
        public string? AddField5 { get; set; }
        [ForeignKey("SocialMediaID")]
        public SocialMedia? SocialMedia { get; set; }
        public int? SocialMediaID { get; set; }
        [ForeignKey("ContactID")]
        public Contact? Contact { get; set; }
        public int? ContactID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
