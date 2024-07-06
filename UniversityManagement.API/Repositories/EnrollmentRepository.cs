using System;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.API.Interfaces;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Repositories
{
	public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
		public EnrollmentRepository(CoreContext context) : base(context)
        {
		}

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _context.Enrollments
                .Include(s => s.Student)
                 .Include(c => c.Course)
                .ToListAsync();
        }

        public async Task<Enrollment> GetByIdAsync(int id)
        {
            return await _context.Enrollments
                .Include(s => s.Student)
                 .Include(c => c.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudent(int studentId)
        {
            return await _context.Enrollments
                                 .Where(e => e.StudentId == studentId)
                                 .Include(e => e.Course)
                                 .ToListAsync();
        }
    }
}

