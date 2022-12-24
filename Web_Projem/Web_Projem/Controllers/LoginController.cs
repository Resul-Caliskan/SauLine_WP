using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using Web_Projem.Models;

namespace Web_Projem.Controllers
{
    public class LoginController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "gcXSL3OsYxwnTQ4l2MlbJ2O1LN3k8gD1ZLbSO0Pp",
            BasePath = "https://crsmartled-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        FirebaseClient client;
        public IActionResult Index() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users user) 
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Users");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Users>();
            Boolean dogru=false;
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Users>(((JProperty)item).Value.ToString()));
                   
            }
            foreach (var item in list)
            {
                if (item.UserName==user.UserName && item.Password==user.Password)
                {
                    dogru = true;
                }
            }
            if (dogru)
            {
                return RedirectToAction("Index","Home",user.UserName);
            }

            return View(list);
        }
        [HttpPost]
        public IActionResult Register(Users user) {
            try
            {
                AddUser(user);
                ModelState.AddModelError(String.Empty,"Added Successfuly");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(String.Empty, ex.Message);
                return View();
            }

            
        }
        private void AddUser(Users user)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = user;
            PushResponse respone = client.Push("Users/",data);
            //data.UserName = respone.Result.name;
            //SetResponse setResponse = client.Set("Users/"+data.UserName,data);
        }
    }
}
