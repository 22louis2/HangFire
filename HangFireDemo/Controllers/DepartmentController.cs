using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HangFireDemo.Model;
using HangFireDemo.Repository;
using HangFireDemo.Interface;
using Hangfire;
using Hangfire.Common;

namespace HangFireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecurringJobManager _jobManager;

        public DepartmentController(IDepartmentService service, IUnitOfWork unitOfWork, IRecurringJobManager jobManager)
        {
            _service = service;
            _unitOfWork = unitOfWork;
            _jobManager = jobManager;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var result = await _service.GetDepartments();
            _jobManager.AddOrUpdate("Get Departments", () => _service.GetDepartments(), Cron.Minutely());

            return Ok(result);
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(string id)
        {
            var department = await _service.GetDepartment(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Department/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(string id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _service.UpdateDepartment(id, department);

            try
            {
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _service.DepartmentExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Department
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            await _service.AddDepartment(department);
            try
            {
                await _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                if (await _service.DepartmentExist(department.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(string id)
        {
            var department = await _service.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }

            await _service.DeleteDepartment(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
