using Microsoft.AspNetCore.Mvc;

namespace OnlinePharmacySystem.Web.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
