using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KetchupMayoSite.Models;
using KetchupMayoSite.Services;

namespace KetchupMayoSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MayoApiController : ControllerBase
    {
        private IMayoService _mayoService;
        public MayoApiController(IMayoService mayoService)
        {
            _mayoService = mayoService;
        }
        // Get method that returns all entities(Mayo)
        // example: /api/ketchup
        [HttpGet]
        public IActionResult Get()
        {
            var mayos = _mayoService.Get();
            return Ok(mayos);
        }

        // example: api/mayo
        // add new entity Mayo
        [HttpPost]
        public IActionResult Post([FromBody] Mayo mayo)
        {
            if (mayo == null)
            {
                return BadRequest("Mayo is null");
            }

            _mayoService.Post(mayo);
            return Ok();
        }

        // example: api/mayo/5
        // used to update an entity
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Mayo mayo)
        {
            if (mayo == null)
            {
                return BadRequest("Ketchup is null");
            }

            Mayo mayoToUpdate = _mayoService.Get(id);
            if (mayoToUpdate == null)
            {
                return NotFound("Could not find the record");
            }
            _mayoService.Put(mayoToUpdate, mayo);
            return NoContent();
        }

        // example: api/mayo/7
        // used to delete an entity

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Mayo mayo = _mayoService.Get(id);
            if (mayo == null)
            {
                return NotFound("Couldn't find the record");
            }

            _mayoService.Delete(id);
            return NoContent();
        }
    }
}