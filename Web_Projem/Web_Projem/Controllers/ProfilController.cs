using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_Projem.Controllers
{
    public class ProfilController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
