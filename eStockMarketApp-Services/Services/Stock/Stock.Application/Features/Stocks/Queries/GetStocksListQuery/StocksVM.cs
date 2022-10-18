using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Queries.GetStocksListQuery
{
    public class StocksVM
    {
        public int Stock_Id { get; set; }
        public int Company_Code { get; set; }
        public decimal Stock_Price { get; set; }
        public DateTime Created_Date { get; set; }
    }
}
