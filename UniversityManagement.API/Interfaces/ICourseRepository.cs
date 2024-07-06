using System;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Interfaces
{
	public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetCoursesByDepartment(int departmentId);
        Task<IEnumerable<Course>> GetCoursesWithInstructors();
    }
}

