using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Commands.AddStock
{
    public class AddStockCommand : IRequest<int>
    {
        public int Company_Code { get; set; }
        public decimal Stock_Price { get; set; }
    }
}
