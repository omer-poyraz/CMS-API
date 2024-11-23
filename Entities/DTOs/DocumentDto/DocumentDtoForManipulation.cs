namespace Entities.DTOs.DocumentDto
{
    public abstract record DocumentDtoForManipulation
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFullPath { get; set; }
        public string? Title { get; set; }
        public string? TitleEN { get; set; }
        public int? DocumentGroupID { get; set; }
        public string? UserId { get; set; }
    }
}
