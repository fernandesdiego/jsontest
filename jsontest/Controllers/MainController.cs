using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.IO;

namespace jsontest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {        
        [HttpGet]
        public IActionResult GetJsonFromFile()
        {
            using (var s = new StreamReader("f.json"))
            {
                return Ok(s.ReadToEnd());
            }                    
        }

        [HttpPost]
        public IActionResult PostJson(Foo foo)
        {
            using (var s = new StreamWriter("f.json"))
            {
                s.WriteLine(JsonSerializer.Serialize(foo));
                return Ok(foo);
            }
        }
    }
}
