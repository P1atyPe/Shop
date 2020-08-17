using Microsoft.AspNetCore.Mvc;
using Shop.Application.StockAdmin;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    public class StocksController : Controller
    {
        private ApplicationDbContext _ctx;

        public StocksController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("stocks")]
        public IActionResult GetStock() => Ok(new GetStock(_ctx).Do());

        [HttpPost("stocks")]
        public async Task<IActionResult> CreateStock([FromBody] CreateStock.Request request) => Ok((await new CreateStock(_ctx).Do(request)));

        [HttpDelete("stocks/{id}")]
        public async Task<IActionResult> DeleteStock(int id) => Ok(await new DeleteStock(_ctx).Do(id));

        [HttpPut("stocks")]
        public async Task<IActionResult> UpdateStocks([FromBody] UpdateStock.Request request) => Ok(await new UpdateStock(_ctx).Do(request));
    }
}
