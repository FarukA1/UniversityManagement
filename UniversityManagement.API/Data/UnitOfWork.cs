using System;
using UniversityManagement.API.Interfaces;
using UniversityManagement.API.Models;
using UniversityManagement.API.Repositories;

namespace UniversityManagement.API.Data
{
	public class UnitOfWork : IUnitOfWork
    {
		private readonly CoreContext _context;

		public UnitOfWork(CoreContext context)
        {
			_context = context;
            Students = new StudentRepository(context);
            Courses = new CourseRepository(context);
            Enrollments = new EnrollmentRepository(context);
            Departments = new DepartmentRepository(context);
            Instructors = new InstructorRepository(context);
            Classrooms = new ClassroomRepository(context);
            CourseAssignments = new CourseAssignmentRepository(context);
            ClassSchedules = new ClassScheduleRepository(context);
        }

        public IStudentRepository Students { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IEnrollmentRepository Enrollments { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public IInstructorRepository Instructors { get; private set; }
        public IClassroomRepository Classrooms { get; private set; }
        public ICourseAssignmentRepository CourseAssignments { get; private set; }
        public IClassScheduleRepository ClassSchedules { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

