using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_Projem.Controllers
{
    public class ProfilController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            TempData["ad"]=HttpContext.Session.GetString("Username");
            return View();
        }
        [HttpPost]
         // Firebase eleman ekleme
        public IActionResult Paylas()
        {
            return View();
        }
    }
}
