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

        public bool IsStockExists(string stockName)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Stocks.Any(s => s.Name == stockName);
            }
        }

        public void AddStock(Stock stock)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {                            
                context.Add(stock);
                context.SaveChanges();                                        
            }
        }

        public List<Stock> GetAllStocks() 
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Stocks.ToList();
            }
        }

        public void DeleteStock(int stockId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var stockToDelete = context.Stocks.FirstOrDefault(s => s.Id == stockId);
                if (stockToDelete != null)
                {
                    context.Stocks.Remove(stockToDelete);
                    context.SaveChanges();
                }
            }
        }
        public void EditStock(int stockId, Stock editedStock)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var existingStock = context.Stocks.FirstOrDefault(s => s.Id == stockId);

                if (existingStock != null)
                {
                    // Kontrollera om editedStock.Name är inte null innan du uppdaterar
                    if (editedStock.Name != null)
                    {
                        existingStock.Name = editedStock.Name;
                    }

                    // Kontrollera om editedStock.Description är inte null innan du uppdaterar
                    if (editedStock.Description != null)
                    {
                        existingStock.Description = editedStock.Description;
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
