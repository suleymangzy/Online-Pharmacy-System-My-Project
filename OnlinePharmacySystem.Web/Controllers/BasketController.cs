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
            var userId = 1; // Örnek kullanıcı ID, oturumdan dinamik olarak almanız gerekecek
            var basket = await _context.Baskets
                .Include(b => b.BasketOrderDetails)
                .ThenInclude(od => od.OrderDetailProduct) // Ürün bilgilerini de dahil ediyoruz
                .Where(b => b.BasketUserID == userId)
                .FirstOrDefaultAsync();

            if (basket == null)
            {
                // Eğer kullanıcıya ait sepet yoksa, boş bir sepet döndürülür
                basket = new Basket
                {
                    BasketOrderDetails = new List<OrderDetails>()
                };
            }

            return View(basket);
        }

        // POST: Basket/AddToBasket/5
        [HttpPost]
        public async Task<IActionResult> AddToBasket(int productId, int quantity = 1)
        {
            var userId = 1; // Örnek kullanıcı ID, oturumdan dinamik olarak almanız gerekecek
            var basket = await _context.Baskets
                .Include(b => b.BasketOrderDetails)
                .Where(b => b.BasketUserID == userId)
                .FirstOrDefaultAsync();

            if (basket == null)
            {
                basket = new Basket
                {
                    BasketUserID = userId,
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
                        OrderDetailProduct = product, // Ürün bilgisini ekliyoruz
                        Quantity = quantity,
                        TotalAmount = product.ProductPrice * quantity,
                        TaxRate = 0.18m // Sabit bir KDV oranı örnek olarak eklenmiştir
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
            return RedirectToAction(nameof(Index));
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
            var userId = 1; // Örnek kullanıcı ID, oturumdan dinamik olarak almanız gerekecek
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
            // Ödeme ve sipariş tamamlama işlemlerini burada yapabilirsiniz
            // Sipariş tamamlandıktan sonra sepeti temizlemeniz gerekebilir
            return RedirectToAction("OrderTracking", "Orders");
        }
    }
}
