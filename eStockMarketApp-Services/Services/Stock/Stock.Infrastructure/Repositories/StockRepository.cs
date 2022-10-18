using Microsoft.EntityFrameworkCore;
using Stock.Application.Contract;
using Stock.Domain.Entities;
using Stock.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Infrastructure.Repositories
{
    public class StockRepository : RepositoryBase<StockEntity>, IStockRepository
    {
        public StockRepository(StockContext dbContext) : base(dbContext)
        {
        }

        public async Task<StockEntity> GetStock(int company_code)
        {
            var stock = await _dbContext.Stocks.Where(o => o.Company_Code == company_code).FirstOrDefaultAsync();
            return stock;
        }

        public async Task<IEnumerable<StockEntity>> GetStocksByCompanyCode(string company_code)
        {
            var stocksList = await _dbContext.Stocks
                                   .Where(o => o.Company_Code == Convert.ToInt32(company_code))
                                   .ToListAsync();
            return stocksList;
        }
    }
}
