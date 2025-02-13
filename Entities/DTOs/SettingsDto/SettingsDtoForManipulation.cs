namespace Entities.DTOs.SettingsDto
{
    public abstract record SettingsDtoForManipulation
    {
        public string? Site { get; init; }
        public ICollection<string>? Files { get; set; }
        public Dictionary<string, string>? Name { get; set; }
        public Dictionary<string, string>? Phone { get; set; }
        public Dictionary<string, string>? Address { get; set; }
        public Dictionary<string, string>? Fax { get; set; }
        public Dictionary<string, string>? Country { get; set; }
        public Dictionary<string, string>? City { get; set; }
        public Dictionary<string, string>? District { get; set; }
        public int? ModuleId { get; init; }
        public string? UserId { get; init; }
    }
}
