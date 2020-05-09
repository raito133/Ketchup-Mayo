using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KetchupMayoSite.Models;
using KetchupMayoSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace KetchupMayoSite.Controllers
{
    [Route("api/ketchup")]
    [ApiController]
    public class KetchupApiController : ControllerBase
    {

        private IKetchupService _ketchupService;
        public KetchupApiController(IKetchupService ketchupService)
        {
            _ketchupService = ketchupService;
        }
        // Get method that returns all entities(Ketchups)
        // example: /api/ketchup
        [HttpGet]
        public IActionResult Get()
        {
            var ketchups = _ketchupService.Get();
            return Ok(ketchups);
        }

        // example: api/ketchup
        // add new entity Ketchup
        [HttpPost]
        public IActionResult Post([FromBody] Ketchup ketchup)
        {
            if (ketchup == null)
            {
                return BadRequest("Ketchup is null");
            }

            _ketchupService.Post(ketchup);
            return Ok();
        }

        // example: api/ketchup/5
        // used to update an entity
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ketchup ketchup)
        {
            if (ketchup == null)
            {
                return BadRequest("Ketchup is null");
            }

            Ketchup ketchupToUpdate = _ketchupService.Get(id);
            if (ketchupToUpdate == null)
            {
                return NotFound("Could not find the record");
            }
            _ketchupService.Put(ketchupToUpdate, ketchup);
            return NoContent();
        }

        // example: api/ketchup/7
        // used to delete an entity

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Ketchup ketchup = _ketchupService.Get(id);
            if (ketchup == null)
            {
                return NotFound("Couldn't find the record");
            }

            _ketchupService.Delete(id);
            return NoContent();
        }



    }
}