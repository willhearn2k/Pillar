using Microsoft.EntityFrameworkCore;
using Pillar.Models;

namespace Pillar.DataContext
{
    public class PlayerContext : DbContext
    {
        public PlayerContext() : base()
        {
            Database.EnsureCreated();
        }

        public PlayerContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=pillar.db");
        }
    }
}