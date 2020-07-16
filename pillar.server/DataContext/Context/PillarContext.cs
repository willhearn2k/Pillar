using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pillar.Server.Models;

namespace Pillar.Server.DataContext.Context
{
    public partial class PillarContext : DbContext
    {
        public PillarContext()
        {
            Database.EnsureCreated();
        }

        public PillarContext(DbContextOptions<PillarContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pillar.db");
        }

        public DbSet<Player> Players { get; set; }
    }
}