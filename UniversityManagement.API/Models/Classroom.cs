using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagement.API.Models
{
	public class Classroom
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<ClassSchedule> ClassSchedules { get; set; }
    }
}

