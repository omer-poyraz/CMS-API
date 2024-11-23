namespace Entities.DTOs.DealerDto
{
    public abstract record DealerDtoForManipulation
    {
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? City { get; init; }
        public string? CityEN { get; init; }
        public string? Address { get; init; }
        public string? AddressEN { get; init; }
        public string? Phone { get; init; }
        public string? Phone2 { get; init; }
        public string? Mail { get; init; }
        public string? Mail2 { get; init; }
        public string? Fax { get; init; }
        public string? Fax2 { get; init; }
        public string? URL { get; init; }
        public string? AddField1 { get; init; }
        public string? AddField2 { get; init; }
        public string? AddField3 { get; init; }
        public string? AddField4 { get; init; }
        public string? AddField5 { get; init; }
        public int? SocialMediaID { get; init; }
        public int? ContactID { get; init; }
        public string? UserId { get; init; }
    }
}
