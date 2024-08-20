using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlinePharmacySystem.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace onlinePharmacySystem.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var userId = 1; // Örnek kullanıcı ID, oturumdan dinamik olarak almanız gerekecek
            var orders = await _context.Orders
                .Include(o => o.OrderPharmacy)
                .Include(o => o.OrderDelivery)
                .Include(o => o.OrderPayment)
                .Where(o => o.OrderUserID == userId)
                .ToListAsync();

            return View(orders);
        }

        // GET: Orders/Detail/5
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.OrderDetailProduct)
                .Include(o => o.OrderPharmacy)
                .Include(o => o.OrderDelivery)
                .Include(o => o.OrderPayment)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}

