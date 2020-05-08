using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadiusCore.App_Data;
using RadiusCore.Models;
using Newtonsoft.Json;

namespace RadiusCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentifierController : ControllerBase
    {
        DatabaseAccess _databaseAccess = new DatabaseAccess();
        // GET: api/Object
        [HttpGet]
        public async Task<string> Get()
        {
            return JsonConvert.SerializeObject(await _databaseAccess.GetIdentifiersAsync(string.Empty));
        }

        // GET: api/Object/5
        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            return JsonConvert.SerializeObject(await _databaseAccess.GetIdentifiersAsync(id));
        }

        // POST: api/Object
        [HttpPost]
        public async Task<IActionResult> Post(RadIdentifierModel identifier)
        {
            try
            {
                if (await _databaseAccess.UpdateIdentifierAsync(identifier))
                {
                    return Ok(JsonConvert.SerializeObject(identifier));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Object/5
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put()
        {
            try
            {
                RadIdentifierModel identifier = new RadIdentifierModel(){Value = "Unknown"};
                DatabaseAccess data = new DatabaseAccess();
                await data.PutIdentifierAsync(identifier);
                return CreatedAtAction(nameof(Put), new { id = identifier.ID }, JsonConvert.SerializeObject(identifier));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Object/5
        [HttpPut("{thing}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody]string thing)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(thing))
                {
                    return NoContent();
                }
                DatabaseAccess data = new DatabaseAccess();
                RadThingModel radThing = JsonConvert.DeserializeObject<RadThingModel>(thing);
                await data.PutThingAsync(radThing);
                return CreatedAtAction(nameof(Put), new { id = radThing.ID }, JsonConvert.SerializeObject(radThing));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{identifierID}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string identifierID)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identifierID))
                {
                    return NoContent();
                }
                DatabaseAccess data = new DatabaseAccess();
                if(await data.DeleteIdentifierAsync(identifierID)){
                    return Accepted();
                }
                else{
                    return BadRequest("Unable to delete " + identifierID);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
