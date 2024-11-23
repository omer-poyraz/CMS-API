using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class FormResponse
    {
        public int FormResponseID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? IpAddress { get; set; }
        [ForeignKey("FormID")]
        public Form? Form { get; set; }
        public int? FormID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
