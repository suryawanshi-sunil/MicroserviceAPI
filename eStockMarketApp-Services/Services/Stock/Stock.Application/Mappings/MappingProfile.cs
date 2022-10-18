using AutoMapper;
using Stock.Application.Features.Stocks.Commands.AddStock;
using Stock.Application.Features.Stocks.Queries.GetStocksListQuery;
using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Stock.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StockEntity, StocksVM>().ReverseMap();
            CreateMap<StockEntity, AddStockCommand>().ReverseMap();

        }
    }
}
