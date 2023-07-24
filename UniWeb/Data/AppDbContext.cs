using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using UniWeb.Data.Models;

namespace UniWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) 
            : base(options)        
        { 
                   
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
