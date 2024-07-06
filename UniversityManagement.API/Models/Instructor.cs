using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagement.API.Models
{
	public class Instructor
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public ICollection<ClassSchedule> ClassSchedules { get; set; }
        public ICollection<Department> AdministratedDepartments { get; set; }
    }
}

