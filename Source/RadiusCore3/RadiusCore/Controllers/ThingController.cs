using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadiusCore.App_Data;
using RadiusCore.Models;

namespace RadiusCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {
        DatabaseAccess _databaseAccess = new DatabaseAccess();
        // GET: api/Object
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Object/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

/*
        // POST: api/Object
        [HttpPost]
        public async Task Post([FromBody] RadThingModel value = null)
        {
            if(value == null){
                value = new RadThingModel();
                value.Text = "New Rad Thing";
            }
            await _databaseAccess.PutThingAsync(value);
        }
*/

        // PUT: api/Object/5
        //[HttpPut("{id}")]
        public async Task Put()
        {
            RadThingModel thing = new RadThingModel();
           
            DatabaseAccess data = new DatabaseAccess();
            await data.PutThingAsync(thing);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
