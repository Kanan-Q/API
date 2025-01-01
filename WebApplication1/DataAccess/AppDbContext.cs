using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<BannedWord> BannedWords { get; set; }
        public AppDbContext(DbContextOptions opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
