using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HealthNautica.Physician.Services;

namespace HealthNautica.Physician.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
       
        public IEnumerable<string> Get()
        {
            var load = HttpContext.Items["payload"] as AuthOptions;
            return new string[] { "value1", "value2" };
        }
        //[HttpGet]
        //public string Test()
        //{
        //    CommonEntities
        //}
    }
}
