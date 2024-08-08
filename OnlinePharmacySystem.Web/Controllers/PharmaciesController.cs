using Microsoft.AspNetCore.Mvc;

namespace OnlinePharmacySystem.Web.Controllers
{
    public class PharmaciesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
