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
    public class JobsController : ControllerBase
    {
        private readonly IJobsInterface jobsInterface;
    
        public JobsController(IJobsInterface _jobsInterface)
        {
            this.jobsInterface = _jobsInterface;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Jobs jobs)
        {
            var responce = await jobsInterface.Save(jobs);
            return Ok(responce);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responce = await jobsInterface.Get();
            if (responce == null) return NotFound();
            return Ok(responce);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var responce = await jobsInterface.Get(id);
            if (responce == null) return NotFound();
            return Ok(responce);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responce = await jobsInterface.Delete(id);

            return Ok(responce);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Jobs jobs)
        {
            var responce = await jobsInterface.Update(id, jobs);
            return Ok(responce);
        }

    }
}
