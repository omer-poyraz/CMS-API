using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Setting
    {
        public int SettingID { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFullPath { get; set; }
        public string? FooterTextTR { get; set; }
        public string? FooterTextEN { get; set; }
        public string? FooterTextAR { get; set; }
        public string? FooterTextFR { get; set; }
        public string? KvkTR { get; set; }
        public string? KvkEN { get; set; }
        public string? KvkAR { get; set; }
        public string? KvkFR { get; set; }
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
        public string? Field6TR { get; set; }
        public string? Field6EN { get; set; }
        public string? Field6AR { get; set; }
        public string? Field6FR { get; set; }
        public string? Field7TR { get; set; }
        public string? Field7EN { get; set; }
        public string? Field7AR { get; set; }
        public string? Field7FR { get; set; }
        public string? Field8TR { get; set; }
        public string? Field8EN { get; set; }
        public string? Field8AR { get; set; }
        public string? Field8FR { get; set; }
        public string? Field9TR { get; set; }
        public string? Field9EN { get; set; }
        public string? Field9AR { get; set; }
        public string? Field9FR { get; set; }
        public string? Field10TR { get; set; }
        public string? Field10EN { get; set; }
        public string? Field10AR { get; set; }
        public string? Field10FR { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Phone3 { get; set; }
        public string? Mail1 { get; set; }
        public string? Mail2 { get; set; }
        public string? Mail3 { get; set; }
        public string? Fax1 { get; set; }
        public string? Fax2 { get; set; }
        public string? Fax3 { get; set; }
        [ForeignKey("SocialMediaWhiteID")]
        [JsonIgnore]
        public SocialMedia? SocialMediaWhite { get; set; }
        public int? SocialMediaWhiteID { get; set; }
        [ForeignKey("SocialMediaDarkID")]
        public SocialMedia? SocialMediaDark { get; set; }
        public int? SocialMediaDarkID { get; set; }
        [ForeignKey("HomeSeoID")]
        public Seo? HomeSeo { get; set; }
        public int? HomeSeoID { get; set; }
        [ForeignKey("ContactSeoID")]
        public Seo? ContactSeo { get; set; }
        public int? ContactSeoID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
