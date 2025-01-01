using Microsoft.EntityFrameworkCore;
using PeriodicTable.API.Model;

namespace PeriodicTable.API.Data
{
    public partial class PeriodicTableContext : DbContext
    {
        public PeriodicTableContext() { }

        public PeriodicTableContext(DbContextOptions<PeriodicTableContext> options) : base(options) { }

        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Discoverer> Discoverers { get; set; }

        // Override OnModelCreating to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Disable auto-increment (identity) for Enumber in Element
            modelBuilder.Entity<Element>()
                .Property(e => e.Enumber)
                .ValueGeneratedNever();  // Prevents auto-increment from being applied
        }
    }
}