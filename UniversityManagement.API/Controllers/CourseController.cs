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
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetStudents()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpGet("bydepartment/{departmentId}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByDepartment(int departmentId)
        {
            var courses = await _unitOfWork.Courses.GetCoursesByDepartment(departmentId);
            return Ok(courses);
        }

        [HttpGet("withinstructors")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesWithInstructors()
        {
            var courses = await _unitOfWork.Courses.GetCoursesWithInstructors();
            return Ok(courses);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateCourse(Course course)
        {
            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Courses.Update(course);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _unitOfWork.Courses.Remove(course);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}

