using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Repositories.EFCore.Config
{
    public class LibraryModelConfig : IEntityTypeConfiguration<LibraryModel>
    {
        public void Configure(EntityTypeBuilder<LibraryModel> builder)
        {
            builder.HasKey(s => s.ID);
        }
    }
}
