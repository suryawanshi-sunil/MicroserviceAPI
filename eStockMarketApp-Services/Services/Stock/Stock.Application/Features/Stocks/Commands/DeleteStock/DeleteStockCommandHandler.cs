using AutoMapper;
using MediatR;
using Stock.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public DeleteStockCommandHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var stocklist = await _stockRepository.GetStocksByCompanyCode(request.Company_Code.ToString());
            if(stocklist.Count() > 0)
            {
                foreach(var stock in stocklist)
                {
                    await _stockRepository.DeleteAsync(stock);
                }
            }
            return Unit.Value;
        }
    }
}
