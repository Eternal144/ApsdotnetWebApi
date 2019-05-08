using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiMySQLActor.Models;
using ApiMySQLActor.Repositories;

namespace ApiMySQLActor.Controllers
{
    [Route("api/[controller]")]
    public class RecordsController : Controller
    {
        private IRecordsRepository records;

        public RecordsController(sakilaContext context)
        {

            records = new RecordsRepository(context);
        }

        // GET api/actors
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(records.GetActors());
        }

        // GET api/actors/101
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Record record = records.GetActorById(id);
            if (record != null)
            {
                return Ok(record);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/actors
        [HttpPost]
        public IActionResult Post([FromBody]Record actor)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int success = records.AddNewRecord   (actor);
            if (success == 1)
            {
                return Created("api/actors", actor);
            }
            return BadRequest();
        }

        // PUT api/actors
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Record actor)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            // int success = actors.UpdateActorById(id, actor);
            int success = records.UpdateActorByIdEntityState(id, actor);

            if (success == 1)
            {
                return Ok();
            }

            return BadRequest();
        }

        // DELETE api/actors
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int success = records.DeleteActorById(id);

            if (success == 1)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}