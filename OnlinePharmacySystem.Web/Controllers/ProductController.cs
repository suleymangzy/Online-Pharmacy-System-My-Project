using Microsoft.AspNetCore.Mvc;

namespace OnlinePharmacySystem.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
