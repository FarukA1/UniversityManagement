using System;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.API.Interfaces;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Repositories
{
	public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
		public InstructorRepository(CoreContext context) : base(context)
        {
		}

        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _context.Instructors
                .Include(i => i.CourseAssignments)
                    .ThenInclude(ca => ca.Course)
                .ToListAsync();
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _context.Instructors
                .Include(i => i.CourseAssignments)
                    .ThenInclude(ca => ca.Course)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Instructor>> GetInstructorsByDepartment(int departmentId)
        {
            return await _context.Instructors
                                 .Where(i => i.CourseAssignments.Any(ca => ca.Course.DepartmentId == departmentId))
                                 .ToListAsync();
        }
    }
}

