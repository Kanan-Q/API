using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Configurations
{
    public class BannedWordConfiguration : IEntityTypeConfiguration<BannedWord>
    {
        public void Configure(EntityTypeBuilder<BannedWord> builder)
        {
            builder.Property(x => x.Text).IsRequired().HasMaxLength(32);
        }
    }
}
