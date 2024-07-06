using System;
using UniversityManagement.API.Interfaces;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Repositories
{
	public class ClassScheduleRepository : Repository<ClassSchedule>, IClassScheduleRepository
    {
		public ClassScheduleRepository(CoreContext context) : base(context)
        {
		}
	}
}

