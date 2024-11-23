namespace Entities.DTOs.SocialDto
{
    public abstract record SocialDtoForManipulation
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFullPath { get; set; }
        public string? Title { get; set; }
        public string? URL { get; set; }
        public int? SocialMediaID { get; set; }
        public string? UserId { get; set; }
    }
}
