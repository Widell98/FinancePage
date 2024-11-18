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
    }
}
