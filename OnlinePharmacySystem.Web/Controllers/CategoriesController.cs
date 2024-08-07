using Microsoft.AspNetCore.Mvc;

namespace OnlinePharmacySystem.Web.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
