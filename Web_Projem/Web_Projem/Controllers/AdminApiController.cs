using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using Microsoft.AspNetCore.Mvc;
using Web_Projem.Models;
using FireSharp.Response;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Projem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminApiController : ControllerBase
    {
        FirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "gcXSL3OsYxwnTQ4l2MlbJ2O1LN3k8gD1ZLbSO0Pp",
            BasePath = "https://crsmartled-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        // GET: api/AdminApi
        [HttpGet]
        [AllowAnonymous]
        public List<Paylasim> Get()
        {
            //Burada Tüm payşlaşımlar paylaşılıyor
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Paylasim");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Paylasim>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Paylasim>(((JProperty)item).Value.ToString()));
            }
            return list;
        }
        // delete api/<valuescontroller>/5
        //[HttpDelete("{id}")]
        //public void delete(int id)
        //{
        //    client = new FireSharp.FirebaseClient(config);
        //    FirebaseResponse response = client.Delete("Paylasim/1");
        //}
        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] Paylasim value)
        //{


        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}


    }
}
