using AutoMapper;
using MediatR;
using Stock.Application.Contract;
using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Commands.AddStock
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, int>
    {
        private readonly IStockRepository _repository;
        private readonly IMapper _mapper;

        public AddStockCommandHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _repository = stockRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            var stockEntity = _mapper.Map<StockEntity>(request);
            var newStock = await _repository.AddAsync(stockEntity);
            return newStock.Stock_Id;
        }
    }
}
