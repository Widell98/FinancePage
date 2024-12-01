using Microsoft.EntityFrameworkCore;
using UniWeb.Data;
using UniWeb.Data.Models;
using UniWebServer.Data.Models;

namespace UniWeb.Services
{
    public class StockServices
    {
        private IDbContextFactory<AppDbContext> _dbContextFactory;

        public StockServices(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool IsStockExists(string name)
        {
            var _dbContext = _dbContextFactory.CreateDbContext();
            return _dbContext.Stocks.Any(s => s.Name.ToLower() == name.ToLower());
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

        public Stock GetStockById(int stockId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Stocks.First(s => s.Id == stockId);
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

                    if (editedStock.AnalysisImageData != null)
                    {
                        existingStock.AnalysisImageData = editedStock.AnalysisImageData;
                    }

                    context.SaveChanges();
                }
            }
        }

        public void UpdateAnalysisImage(int stockId, byte[] analysisImageData)
        {
            var _dbContext = _dbContextFactory.CreateDbContext();
            var stock = _dbContext.Stocks.FirstOrDefault(s => s.Id == stockId);
            if (stock != null)
            {
                stock.AnalysisImageData = analysisImageData;
                _dbContext.SaveChanges();
            }
        }

        public List<StockHistory> GetStockHistory(int stockId)
        {
            var _dbContext = _dbContextFactory.CreateDbContext();

            return _dbContext.StockHistory
                .Where(h => h.StockId == stockId)
                .OrderByDescending(h => h.UploadDate)
                .ToList();
        }

        public void AddStockHistory(int stockId, string analysisImagePath, string description)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var history = new StockHistory
                {
                    StockId = stockId,
                    AnalysisImagePath = analysisImagePath,
                    Description = description
                };
                context.StockHistory.Add(history);
                context.SaveChanges();
            }
        }

        public StockHistory GetStockHistoryById(int historyId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.StockHistory.FirstOrDefault(h => h.Id == historyId);
            }
        }


        public Stock GetStockByName(string name)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Stocks.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
            }
        }
    }
}

