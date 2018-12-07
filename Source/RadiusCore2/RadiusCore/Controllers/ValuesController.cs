using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RadiusCore.Models;
using RadiusCore.MongoDB;
using RadiusCore.Settings;
namespace RadiusCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MongoDBCollections _myConfiguration;
        public ValuesController(IOptions<MongoDBCollections> myConfiguration)
        {
            _myConfiguration = myConfiguration.Value;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            string value1 = CustomAppSettings.Settings["MongoDB_Configuration:ConnectionString"];
            string value2 = CustomAppSettings.Settings["MongoDB_Configuration:DatabaseName"];
            MongoDBMaintenance build = new MongoDBMaintenance(_myConfiguration);
            await build.BuildIndexesAsync();


            return new string[] { value1, value2 };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
