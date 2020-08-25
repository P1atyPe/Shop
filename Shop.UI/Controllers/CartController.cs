using Microsoft.AspNetCore.Mvc;
using Shop.Application.Cart;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        private ApplicationDbContext _ctx;

        public CartController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> AddOne(int stockId)
        {
            var request = new AddToCart.Request
            {
                StockId = stockId,
                Qty = 1
            };

            var addToCart = new AddToCart(HttpContext.Session, _ctx);

            var success = await addToCart.Do(request);

            if (success)
            {
                return Ok("Item added to cart");
            }
            return BadRequest("Failed to Add to Cart");
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> RemoveOne(int stockId)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                Qty = 1
            };

            var addToCart = new RemoveFromCart(HttpContext.Session, _ctx);

            var success = await addToCart.Do(request);

            if (success)
            {
                return Ok("Item removed from cart");
            }
            return BadRequest("Failed to removed item from Cart");
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> RemoveAll(int stockId)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                All = true
            };

            var addToCart = new RemoveFromCart(HttpContext.Session, _ctx);

            var success = await addToCart.Do(request);

            if (success)
            {
                return Ok("Item removed all from cart");
            }
            return BadRequest("Failed to removed all items from Cart");
        }
    }
}
