using Microsoft.EntityFrameworkCore;
using UniWeb.Data.Models;
using UniWebServer.Data.Models;

namespace UniWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<StockHistory> StockHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired() // Obligatoriskt fält
                    .HasMaxLength(100); // Maxlängd för namnet

                entity.HasIndex(e => e.Name)
                    .IsUnique(); // Säkerställer att namnet är unikt
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
