using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Projem.Models;
using Microsoft.AspNetCore.Authorization;

namespace Web_Projem.Controllers
{
    public class CallAdminApiController : Controller
    {
        FirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "gcXSL3OsYxwnTQ4l2MlbJ2O1LN3k8gD1ZLbSO0Pp",
            BasePath = "https://crsmartled-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        [Authorize(Roles ="Admin")]
        public async  Task<IActionResult> Index()
        {
            List<Paylasim> paylasim = new List<Paylasim>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7067/api/AdminApi");
            dynamic resString = await response.Content.ReadAsStringAsync();
            paylasim = JsonConvert.DeserializeObject<List<Paylasim>>(resString);
            return View(paylasim);
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Delete("Paylasim/"+id);
            return RedirectToAction("Index","CallAdminApi");
        }
    }
}
