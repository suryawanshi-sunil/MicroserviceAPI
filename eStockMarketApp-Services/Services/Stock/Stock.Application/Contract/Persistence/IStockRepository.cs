using Stock.Application.Contract.Persistence;
using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Contract
{
    public interface IStockRepository : IAsyncRepository<StockEntity>
    {
        Task<IEnumerable<StockEntity>> GetStocksByCompanyCode(string company_code);
        Task<StockEntity> GetStock(int company_code);
    }
}
