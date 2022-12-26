using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Web_Projem.Models;

namespace Web_Projem.Controllers
{
    public class ProfilController : Controller
    {
        FirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "gcXSL3OsYxwnTQ4l2MlbJ2O1LN3k8gD1ZLbSO0Pp",
            BasePath = "https://crsmartled-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        [Authorize]
        public IActionResult Index()
        {
            Paylasim paylasim = new Paylasim();
            TempData["ad"] = HttpContext.Session.GetString("Username");
            paylasim.User = HttpContext.Session.GetString("Username");
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Paylasim");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Paylasim>();
            var Liste = new List<Paylasim>();
            Boolean dogru = false;
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Paylasim>(((JProperty)item).Value.ToString()));

            }
            foreach (var item in list)
            {
                if (item.User == paylasim.User)
                {
                    Liste.Add(item);
                   
                }
            }
            ViewBag.Liste = Liste;
            return View();
        }
        public IActionResult GonderiOlustur()
        {
            TempData["ad"] = HttpContext.Session.GetString("Username");
            return View();
        }
        [HttpPost]
        // Firebase eleman ekleme
        public IActionResult Paylas(Paylasim paylasim)
        {
            try
            {
            durum: Random random = new Random();
                int id = random.Next();
                paylasim.User = HttpContext.Session.GetString("Username");
                paylasim.Id = id;
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("Paylasim");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                var list = new List<Paylasim>();
                Boolean dogru = false;
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<Paylasim>(((JProperty)item).Value.ToString()));

                }
                foreach (var item in list)
                {
                    if (item.User == paylasim.User && item.Id == paylasim.Id)
                    {
                        goto durum;
                    }
                }


                AddUser(paylasim);
                ModelState.AddModelError(String.Empty, "Published Successfuly");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(String.Empty, ex.Message);
                return View();
            }
        }
        private void AddUser(Paylasim send)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = send;
            PushResponse respone = client.Push("Paylasim/", data);
            //data.UserName = respone.Result.name;
            //SetResponse setResponse = client.Set("Users/"+data.UserName,data);
        }
    }
}
