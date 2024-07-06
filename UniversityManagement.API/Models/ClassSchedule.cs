using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagement.API.Models
{
	public class ClassSchedule
	{
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ClassroomId { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Course? Course { get; set; }
        public Classroom? Classroom { get; set; }
        public Instructor? Instructor { get; set; }
    }
}

