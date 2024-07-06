using System;
namespace UniversityManagement.API.Interfaces
{
	public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        ICourseRepository Courses { get; }
        IEnrollmentRepository Enrollments { get; }
        IDepartmentRepository Departments { get; }
        IInstructorRepository Instructors { get; }
        IClassroomRepository Classrooms { get; }
        ICourseAssignmentRepository CourseAssignments { get; }
        IClassScheduleRepository ClassSchedules { get; }
        Task<int> CompleteAsync();
    }
}

