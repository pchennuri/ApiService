using ApiService.Interfaces;
using ApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationInterface locationinterface;
        public LocationController(ILocationInterface _locationinterface)
        {
            this.locationinterface = _locationinterface;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Location location)
        {
            var responce = await locationinterface.Save(location);
            return Ok(responce);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responce = await locationinterface.Get();
            if (responce == null) return NotFound();
            return Ok(responce);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var responce = await locationinterface.Get(id);
            if (responce == null) return NotFound();
            return Ok(responce);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responce = await locationinterface.Delete(id);

            return Ok(responce);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Location location)
        {
            var responce = await locationinterface.Update(id, location);
            return Ok(responce);
        }

    }
}
