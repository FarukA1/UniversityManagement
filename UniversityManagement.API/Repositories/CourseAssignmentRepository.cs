using System;
using UniversityManagement.API.Interfaces;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Repositories
{
	public class CourseAssignmentRepository : Repository<CourseAssignment>, ICourseAssignmentRepository
    {
		public CourseAssignmentRepository(CoreContext context) : base(context)
        {
		}
	}
}

