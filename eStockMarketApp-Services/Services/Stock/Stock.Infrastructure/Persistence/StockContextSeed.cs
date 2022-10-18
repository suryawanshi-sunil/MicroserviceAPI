using Microsoft.Extensions.Logging;
using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Infrastructure.Persistence
{
    public class StockContextSeed
    {
        public static async Task SeedAsync(StockContext stockContext, ILogger<StockContextSeed> logger)
        {
            if (stockContext.Stocks.Any())
            {
                stockContext.Stocks.AddRange(GetPreconfiguredOrders());
                await stockContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(StockContext).Name);
            }
        }

        private static IEnumerable<StockEntity> GetPreconfiguredOrders()
        {
            return new List<StockEntity>
            {
                new StockEntity() {Company_Code = 2, Stock_Price = 500, Created_Date = DateTime.Now }
            };
        }
    }
}
