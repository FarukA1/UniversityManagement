using System;
using UniversityManagement.API.Interfaces;
using UniversityManagement.API.Models;

namespace UniversityManagement.API.Repositories
{
	public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
		public DepartmentRepository(CoreContext context) : base(context)
        {
		}
	}
}

