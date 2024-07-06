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
    public class CourseAssignmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseAssignmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseAssignment>>> GetCourseAssignments()
        {
            var courseAssignments = await _unitOfWork.CourseAssignments.GetAllAsync();
            return Ok(courseAssignments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseAssignment>> GetCourseAssignment(int id)
        {
            var courseAssignment = await _unitOfWork.CourseAssignments.GetByIdAsync(id);
            if (courseAssignment == null)
            {
                return NotFound();
            }
            return Ok(courseAssignment);
        }

        [HttpPost]
        public async Task<ActionResult<CourseAssignment>> CreateCourseAssignment(CourseAssignment courseAssignment)
        {
            await _unitOfWork.CourseAssignments.AddAsync(courseAssignment);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetCourseAssignment), new { id = courseAssignment.InstructorId }, courseAssignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseAssignment(int id, CourseAssignment courseAssignment)
        {
            if (id != courseAssignment.InstructorId)
            {
                return BadRequest();
            }

            _unitOfWork.CourseAssignments.Update(courseAssignment);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseAssignment(int id)
        {
            var courseAssignment = await _unitOfWork.CourseAssignments.GetByIdAsync(id);
            if (courseAssignment == null)
            {
                return NotFound();
            }

            _unitOfWork.CourseAssignments.Remove(courseAssignment);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}

