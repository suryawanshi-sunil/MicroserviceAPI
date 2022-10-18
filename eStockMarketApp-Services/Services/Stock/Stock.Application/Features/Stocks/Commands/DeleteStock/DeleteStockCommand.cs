using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommand : IRequest
    {
        public int Company_Code { get; set; }
    }
}
