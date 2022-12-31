using Microsoft.AspNetCore.Mvc;

namespace Web_Projem.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
