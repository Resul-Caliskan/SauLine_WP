using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Projem.Models;

namespace Web_Projem.Controllers
{
    public class CallAdminApiController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            List<Paylasim> paylasim = new List<Paylasim>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7067/api/AdminApi");
            dynamic resString = await response.Content.ReadAsStringAsync();
            paylasim = JsonConvert.DeserializeObject<List<Paylasim>>(resString);
            return View(paylasim);
        }
    }
}
