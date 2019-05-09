using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleWebApiAspNetCore.Models;
using SampleWebApiAspNetCore.Repositories;

namespace SampleWebApiAspNetCore.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Route("api/[controller]")]
    public class RecordsController : Controller
    {
        private IRecordsRepository records;

        public RecordsController(sakilaContext context)
        {

            records = new RecordsRepository(context);
        }

        // GET api/records
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(records.GetActors());
        }

        // GET api/records/101
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

        // POST api/records
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
                return Created("api/records", actor);
            }
            return BadRequest();
        }

        // PUT api/records
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Record actor)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            int success = records.UpdateActorByIdEntityState(id, actor);

            if (success == 1)
            {
                return Ok();
            }

            return BadRequest();
        }

        // DELETE api/records
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