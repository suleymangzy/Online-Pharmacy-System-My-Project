using Microsoft.AspNetCore.Mvc;
using onlinePharmacySystem.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace onlinePharmacySystem.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: User/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Users user)
        {
            if (!ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Bütün alanları doldurun";
                return View(user);
            }

            try
            {
                user.UserCreatedAt = DateTime.Now;
                user.UserRoleID = 1; // Default role ID for a new user

                _context.Users.Add(user);
                int result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    TempData["SuccessMessage"] = "Başarıyla sisteme kayıt edildiniz.";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["SuccessMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
                    ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.");
            }

            return View(user);
        }

        // GET: User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string UserName, string UserPassword)
        {
            var user = _context.Users.FirstOrDefault(u
                => u.UserName == UserName
                && u.UserPassword == UserPassword
                && u.UserID > 0
            );

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
                return View();
            }

            // Set user ID in session
            HttpContext.Session.SetInt32("UserID", user.UserID);

            return RedirectToAction("Index", "Home");
        }
    }
}

