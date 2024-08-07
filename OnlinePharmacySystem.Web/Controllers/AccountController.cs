using Microsoft.AspNetCore.Mvc;

namespace OnlinePharmacySystem.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
