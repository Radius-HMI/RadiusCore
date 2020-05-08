﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadiusCore.App_Data;
using RadiusCore.Models;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace RadiusCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {
        DatabaseAccess _databaseAccess = new DatabaseAccess();
        // GET: api/Object
        [HttpGet]
        public async Task<string> Get()
        {
            return JsonConvert.SerializeObject(await _databaseAccess.GetThingAsync(string.Empty));
        }

        // GET: api/Object/5
        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            return JsonConvert.SerializeObject(await _databaseAccess.GetThingAsync(id));
        }


        // POST: api/Object
        [HttpPost]
        public async Task<IActionResult> Post(RadThingModel thing)
        {
            try
            {
                if (await _databaseAccess.UpdateThingAsync(thing))
                {
                    return Ok(JsonConvert.SerializeObject(thing));
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
                RadThingModel thing = new RadThingModel();
                RadThingPropertyModel newProperty = new RadThingPropertyModel()
                {
                    ID = Guid.NewGuid().ToString(),
                    Value = "New property",
                    TypeID = "Need ID"
                };
                thing.WriteSecurityLevel.Add(new RadIdentifierModel()
                {
                    ID = Guid.NewGuid().ToString(),
                    Value = "New Security Group"
                });
                RadIdentifierModel securityGroup = new RadIdentifierModel()
                {
                    ID = Guid.NewGuid().ToString(),
                    Value = "New Security Group"
                };
                newProperty.WriteSecurityGroups = new List<RadIdentifierModel>() { securityGroup };
                thing.Properties.Add(newProperty);
                DatabaseAccess data = new DatabaseAccess();
                await data.PutThingAsync(thing);
                return CreatedAtAction(nameof(Put), new { id = thing.ID }, JsonConvert.SerializeObject(thing));
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
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{thingID}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string thingID)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(thingID))
                {
                    return NoContent();
                }
                DatabaseAccess data = new DatabaseAccess();
                if(await data.DeleteThingAsync(thingID)){
                    return Accepted();
                }
                else{
                    return BadRequest("Unable to delete " + thingID);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
