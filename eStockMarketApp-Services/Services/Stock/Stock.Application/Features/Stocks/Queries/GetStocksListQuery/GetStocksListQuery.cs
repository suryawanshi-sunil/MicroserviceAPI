using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Queries.GetStocksListQuery
{
    public class GetStocksListQuery : IRequest<List<StocksVM>>
    {
        public string Company_Code { get; set; }

        public GetStocksListQuery(string companycode)
        {
            Company_Code = companycode ?? throw new ArgumentNullException(nameof(companycode));
        }
    }
}
