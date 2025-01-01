using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Configurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.Property(y => y.Text).IsRequired().HasMaxLength(32);
            builder.HasOne(y => y.Language).WithMany(y => y.Words).HasForeignKey(y => y.LangCode);
            builder.HasMany(y => y.BannedWords).WithOne(y => y.Words).HasForeignKey(y => y.WordId);
        }
    }
}
