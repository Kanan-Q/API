using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasOne(y => y.Language).WithMany(y => y.Games).HasForeignKey(y => y.LangCode);
        }
    }
}
