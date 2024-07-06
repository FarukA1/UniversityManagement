using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagement.API.Interfaces;
using UniversityManagement.API.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassScheduleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassScheduleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassSchedule>>> GetClassSchedules()
        {
            var classSchedules = await _unitOfWork.ClassSchedules.GetAllAsync();
            return Ok(classSchedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassSchedule>> GetClassSchedule(int id)
        {
            var classSchedule = await _unitOfWork.ClassSchedules.GetByIdAsync(id);
            if (classSchedule == null)
            {
                return NotFound();
            }
            return Ok(classSchedule);
        }

        [HttpPost]
        public async Task<ActionResult<ClassSchedule>> CreateClassSchedule(ClassSchedule classSchedule)
        {
            await _unitOfWork.ClassSchedules.AddAsync(classSchedule);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetClassSchedule), new { id = classSchedule.Id }, classSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassSchedule(int id, ClassSchedule classSchedule)
        {
            if (id != classSchedule.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ClassSchedules.Update(classSchedule);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassSchedule(int id)
        {
            var classSchedule = await _unitOfWork.ClassSchedules.GetByIdAsync(id);
            if (classSchedule == null)
            {
                return NotFound();
            }

            _unitOfWork.ClassSchedules.Remove(classSchedule);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}

