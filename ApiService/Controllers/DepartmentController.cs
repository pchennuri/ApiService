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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentInterface departmentInterface;
        public DepartmentController(IDepartmentInterface _departmentInterface)
        {
            this.departmentInterface = _departmentInterface;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            var responce = await departmentInterface.Save(department);
            return Ok(responce);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responce = await departmentInterface.Get();
            if (responce == null) return NotFound();
            return Ok(responce);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var responce = await departmentInterface.Get(id);
            if (responce == null) return NotFound();
            return Ok(responce);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responce = await departmentInterface.Delete(id);

            return Ok(responce);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Department department)
        {
            var responce = await departmentInterface.Update(id, department);
            return Ok(responce);
        }

    }
}
