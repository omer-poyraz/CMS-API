using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class SettingConfig : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(s => s.SettingID);
            builder.HasData(
                new Setting
                {
                    SettingID = 1,
                    FooterTextTR = "",
                    FooterTextEN = "",
                    FooterTextAR = "",
                    FooterTextFR = "",
                    KvkTR = "",
                    KvkEN = "",
                    KvkAR = "",
                    KvkFR = "",
                    Field1TR = "",
                    Field1EN = "",
                    Field1AR = "",
                    Field1FR = "",
                    Field2TR = "",
                    Field2EN = "",
                    Field2AR = "",
                    Field2FR = "",
                    Field3TR = "",
                    Field3EN = "",
                    Field3AR = "",
                    Field3FR = "",
                    Field4TR = "",
                    Field4EN = "",
                    Field4AR = "",
                    Field4FR = "",
                    Field5TR = "",
                    Field5EN = "",
                    Field5AR = "",
                    Field5FR = "",
                    Field6TR = "",
                    Field6EN = "",
                    Field6AR = "",
                    Field6FR = "",
                    Field7TR = "",
                    Field7EN = "",
                    Field7AR = "",
                    Field7FR = "",
                    Field8TR = "",
                    Field8EN = "",
                    Field8AR = "",
                    Field8FR = "",
                    Field9TR = "",
                    Field9EN = "",
                    Field9AR = "",
                    Field9FR = "",
                    Field10TR = "",
                    Field10EN = "",
                    Field10AR = "",
                    Field10FR = "",
                    Phone1 = "",
                    Phone2 = "",
                    Phone3 = "",
                    Mail1 = "",
                    Mail2 = "",
                    Mail3 = "",
                    Fax1 = "",
                    Fax2 = "",
                    Fax3 = "",
                }
            );
        }
    }
}
