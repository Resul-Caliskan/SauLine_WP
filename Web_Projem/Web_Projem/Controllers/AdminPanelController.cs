using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Web_Projem.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Web_Projem.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "gcXSL3OsYxwnTQ4l2MlbJ2O1LN3k8gD1ZLbSO0Pp",
            BasePath = "https://crsmartled-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> _Home(Users users)
        {
            if (users.UserName== "B191210002@sakarya.edu.tr" && users.Password=="B191210002")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,"Admin"),
                    
                };
                var userId = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(userId);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                HttpContext.Session.SetString("Username", users.UserName);
                return RedirectToAction("Home","AdminPanel");   
            }
            return View("Hata");
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Home()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Paylasim");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Paylasim>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Paylasim>(((JProperty)item).Value.ToString()));
            }

            ViewBag.Liste = list;
            return View();
            
        }
    }
}
