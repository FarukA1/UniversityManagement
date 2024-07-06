using System;
using UniversityManagement.API.Interfaces;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Repositories
{
	public class ClassroomRepository : Repository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(CoreContext context) : base(context)
        {
        }
    }
}

