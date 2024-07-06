using System;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Interfaces
{
	public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<IEnumerable<Student>> GetStudentsByCourse(int courseId);
        Task<IEnumerable<Student>> GetStudentsWithEnrollments();
    }
}

