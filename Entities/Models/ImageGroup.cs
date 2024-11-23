namespace Entities.Models
{
    public class ImageGroup
    {
        public int ImageGroupID { get; set; }
        public string? TitleTR { get; set; }
        public string? TitleEN { get; set; }
        public string? TitleAR { get; set; }
        public string? TitleFR { get; set; }
        public string? DescriptionTR { get; set; }
        public string? DescriptionEN { get; set; }
        public string? DescriptionAR { get; set; }
        public string? DescriptionFR { get; set; }
        public string? Field1TR { get; set; }
        public string? Field1EN { get; set; }
        public string? Field1AR { get; set; }
        public string? Field1FR { get; set; }
        public string? Field2TR { get; set; }
        public string? Field2EN { get; set; }
        public string? Field2AR { get; set; }
        public string? Field2FR { get; set; }
        public string? Field3TR { get; set; }
        public string? Field3EN { get; set; }
        public string? Field3AR { get; set; }
        public string? Field3FR { get; set; }
        public string? Field4TR { get; set; }
        public string? Field4EN { get; set; }
        public string? Field4AR { get; set; }
        public string? Field4FR { get; set; }
        public string? Field5TR { get; set; }
        public string? Field5EN { get; set; }
        public string? Field5AR { get; set; }
        public string? Field5FR { get; set; }
        public int Sort { get; set; }
        public ICollection<Image>? Images { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
