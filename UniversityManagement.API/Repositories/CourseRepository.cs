using System;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.API.Interfaces;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(CoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.Enrollments)
                    .ThenInclude(e => e.Student)
                .ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Enrollments)
                    .ThenInclude(e => e.Student)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Course>> GetCoursesByDepartment(int departmentId)
        {
            return await _context.Courses
                                 .Where(c => c.DepartmentId == departmentId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesWithInstructors()
        {
            return await _context.Courses
                                 .Include(c => c.CourseAssignments)
                                 .ThenInclude(ca => ca.Instructor)
                                 .ToListAsync();
        }
    }
}

