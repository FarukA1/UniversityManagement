using System;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.API.Interfaces;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Repositories
{
	public class StudentRepository : Repository<Student>, IStudentRepository
    {

        public StudentRepository(CoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudentsByCourse(int courseId)
        {
            return await _context.Students
                                 .Where(s => s.Enrollments.Any(e => e.CourseId == courseId))
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsWithEnrollments()
        {
            return await _context.Students
                                 .Include(s => s.Enrollments)
                                 .ThenInclude(e => e.Course)
                                 .ToListAsync();
        }
    }
}

