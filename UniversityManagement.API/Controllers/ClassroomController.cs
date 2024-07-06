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
    public class ClassroomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassroomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
        {
            var classrooms = await _unitOfWork.Classrooms.GetAllAsync();
            return Ok(classrooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(int id)
        {
            var classroom = await _unitOfWork.Classrooms.GetByIdAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return Ok(classroom);
        }

        [HttpPost]
        public async Task<ActionResult<Classroom>> CreateClassroom(Classroom classroom)
        {
            await _unitOfWork.Classrooms.AddAsync(classroom);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetClassroom), new { id = classroom.Id }, classroom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassroom(int id, Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Classrooms.Update(classroom);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            var classroom = await _unitOfWork.Classrooms.GetByIdAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            _unitOfWork.Classrooms.Remove(classroom);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}

