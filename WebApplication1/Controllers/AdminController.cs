using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Mess = "to jest strona dla zalogwanych";
            return View();
        }
        [AllowAnonymous]
        public IActionResult Gosc()
        {
            ViewBag.Mess = "to jest strona dla wszystkich";
            return View();
        }
        
    }
}
