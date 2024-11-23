using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;

namespace Entities.DTOs.SettingDto
{
    public record SettingDto
    {
        public int SettingID { get; init; }
        public string? FileName { get; init; }
        public string? FilePath { get; init; }
        public string? FileFullPath { get; init; }
        public string? FooterTextTR { get; init; }
        public string? FooterTextEN { get; init; }
        public string? FooterTextAR { get; init; }
        public string? FooterTextFR { get; init; }
        public string? KvkTR { get; init; }
        public string? KvkEN { get; init; }
        public string? KvkAR { get; init; }
        public string? KvkFR { get; init; }
        public string? Field1TR { get; init; }
        public string? Field1EN { get; init; }
        public string? Field1AR { get; init; }
        public string? Field1FR { get; init; }
        public string? Field2TR { get; init; }
        public string? Field2EN { get; init; }
        public string? Field2AR { get; init; }
        public string? Field2FR { get; init; }
        public string? Field3TR { get; init; }
        public string? Field3EN { get; init; }
        public string? Field3AR { get; init; }
        public string? Field3FR { get; init; }
        public string? Field4TR { get; init; }
        public string? Field4EN { get; init; }
        public string? Field4AR { get; init; }
        public string? Field4FR { get; init; }
        public string? Field5TR { get; init; }
        public string? Field5EN { get; init; }
        public string? Field5AR { get; init; }
        public string? Field5FR { get; init; }
        public string? Field6TR { get; init; }
        public string? Field6EN { get; init; }
        public string? Field6AR { get; init; }
        public string? Field6FR { get; init; }
        public string? Field7TR { get; init; }
        public string? Field7EN { get; init; }
        public string? Field7AR { get; init; }
        public string? Field7FR { get; init; }
        public string? Field8TR { get; init; }
        public string? Field8EN { get; init; }
        public string? Field8AR { get; init; }
        public string? Field8FR { get; init; }
        public string? Field9TR { get; init; }
        public string? Field9EN { get; init; }
        public string? Field9AR { get; init; }
        public string? Field9FR { get; init; }
        public string? Field10TR { get; init; }
        public string? Field10EN { get; init; }
        public string? Field10AR { get; init; }
        public string? Field10FR { get; init; }
        public string? Phone1 { get; init; }
        public string? Phone2 { get; init; }
        public string? Phone3 { get; init; }
        public string? Mail1 { get; init; }
        public string? Mail2 { get; init; }
        public string? Mail3 { get; init; }
        public string? Fax1 { get; init; }
        public string? Fax2 { get; init; }
        public string? Fax3 { get; init; }
        public SocialMedia? SocialMediaWhite { get; init; }
        public int? SocialMediaWhiteID { get; init; }
        public SocialMedia? SocialMediaDark { get; init; }
        public int? SocialMediaDarkID { get; init; }
        public Seo? HomeSeo { get; init; }
        public int? HomeSeoID { get; init; }
        public Seo? ContactSeo { get; init; }
        public int? ContactSeoID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
