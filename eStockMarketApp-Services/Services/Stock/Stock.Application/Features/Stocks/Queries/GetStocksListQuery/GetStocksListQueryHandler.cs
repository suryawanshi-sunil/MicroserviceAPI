using AutoMapper;
using MediatR;
using Stock.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Queries.GetStocksListQuery
{
    public class GetStocksListQueryHandler : IRequestHandler<GetStocksListQuery, List<StocksVM>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetStocksListQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<List<StocksVM>> Handle(GetStocksListQuery request, CancellationToken cancellationToken)
        {
            var stocksList = await _stockRepository.GetStocksByCompanyCode(request.Company_Code);
            return _mapper.Map<List<StocksVM>>(stocksList);
        }
    }
}
