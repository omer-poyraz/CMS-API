using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class DocumentGroupConfig : IEntityTypeConfiguration<DocumentGroup>
    {
        public void Configure(EntityTypeBuilder<DocumentGroup> builder)
        {
            builder.HasKey(s=>s.DocumentGroupID);
        }
    }
}
