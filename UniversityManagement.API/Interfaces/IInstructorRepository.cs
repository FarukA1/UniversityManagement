using System;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Interfaces
{
	public interface IInstructorRepository : IRepository<Instructor>
    {
        Task<IEnumerable<Instructor>> GetAllAsync();
        Task<Instructor> GetByIdAsync(int id);
        Task<IEnumerable<Instructor>> GetInstructorsByDepartment(int departmentId);
    }
}

