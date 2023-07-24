using Microsoft.EntityFrameworkCore;
using UniWeb.Data;
using UniWeb.Data.Models;

namespace UniWeb.Services
{
    public class StockServices
    {
        private IDbContextFactory<AppDbContext> _dbContextFactory;

        public StockServices(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddStock(Stock stock)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Add(stock);
                context.SaveChanges();
            }
        }
    }
}
