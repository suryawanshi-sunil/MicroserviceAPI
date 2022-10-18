using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.Features.Stocks.Commands.AddStock;
using Stock.Application.Features.Stocks.Commands.DeleteStock;
using Stock.Application.Features.Stocks.Queries.GetStocksListQuery;
using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Stock.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{companycode}", Name = "GetStock")]
        [ProducesResponseType(typeof(IEnumerable<StocksVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StocksVM>>> GetStockByCompanyCode(string companycode, DateTime startdate, DateTime enddate)
        {
            var query = new GetStocksListQuery(companycode);
            var stocks = await _mediator.Send(query);
            IEnumerable<StocksVM> filterdStocks = stocks.Where(i => i.Created_Date.Date >= startdate.Date && i.Created_Date.Date <= enddate.Date).OrderByDescending(x => x.Created_Date).ToList();

            return Ok(filterdStocks);
        }

        [HttpPost(Name = "AddStock")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddStock([FromBody] AddStockCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{companycode}", Name = "DeleteStock")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteStock(string companycode)
        {
            var command = new DeleteStockCommand() { Company_Code = Convert.ToInt32(companycode) };
            var stock = await _mediator.Send(command);
            return NoContent();
        }

    }
}
