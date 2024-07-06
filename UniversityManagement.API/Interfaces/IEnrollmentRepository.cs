using System;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Interfaces
{
	public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        Task<IEnumerable<Enrollment>> GetAllAsync();
        Task<Enrollment> GetByIdAsync(int id);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudent(int studentId);
    }
}

