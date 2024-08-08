using Microsoft.AspNetCore.Mvc;
using onlinePharmacySystem.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace onlinePharmacySystem.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }
    }
}

