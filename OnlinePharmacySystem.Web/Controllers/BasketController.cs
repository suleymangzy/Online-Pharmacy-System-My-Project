using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlinePharmacySystem.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace onlinePharmacySystem.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Basket
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var basket = await _context.Baskets
                .Include(b => b.BasketOrderDetails)
                .ThenInclude(od => od.OrderDetailProduct)
                .Where(b => b.BasketUserID == userId)
                .FirstOrDefaultAsync();

            if (basket == null)
            {
                basket = new Basket
                {
                    BasketOrderDetails = new List<OrderDetails>()
                };
            }

            return View(basket);
        }

        // POST: Basket/AddToBasket/5
        [HttpPost]
        public async Task<IActionResult> AddToBasket(int productId, int quantity)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var basket = await _context.Baskets
                .Include(b => b.BasketOrderDetails)
                .Where(b => b.BasketUserID == userId)
                .FirstOrDefaultAsync();

            if (basket == null)
            {
                basket = new Basket
                {
                    BasketUserID = userId.Value,
                    BasketDate = DateTime.Now,
                    BasketOrderDetails = new List<OrderDetails>()
                };
                _context.Baskets.Add(basket);
            }

            var orderDetail = basket.BasketOrderDetails
                .FirstOrDefault(od => od.ProductID == productId);

            if (orderDetail == null)
            {
                var product = await _context.Products.FindAsync(productId);
                if (product != null)
                {
                    orderDetail = new OrderDetails
                    {
                        ProductID = productId,
                        OrderDetailProduct = product,
                        Quantity = quantity,
                        TotalAmount = product.ProductPrice * quantity,
                        TaxRate = 0.18m // Example tax rate
                    };
                    basket.BasketOrderDetails.Add(orderDetail);
                }
            }
            else
            {
                orderDetail.Quantity += quantity;
                orderDetail.TotalAmount += orderDetail.OrderDetailProduct.ProductPrice * quantity;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Basket");
        }

        // POST: Basket/RemoveFromBasket/5
        [HttpPost]
        public async Task<IActionResult> RemoveFromBasket(int orderDetailId)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(orderDetailId);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Basket/ClearBasket
        [HttpPost]
        public async Task<IActionResult> ClearBasket()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var basket = await _context.Baskets
                .Include(b => b.BasketOrderDetails)
                .Where(b => b.BasketUserID == userId)
                .FirstOrDefaultAsync();

            if (basket != null)
            {
                _context.OrderDetails.RemoveRange(basket.BasketOrderDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Basket/Checkout
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            // Payment and order completion logic here
            return RedirectToAction("OrderTracking", "Orders");
        }
    }
}
