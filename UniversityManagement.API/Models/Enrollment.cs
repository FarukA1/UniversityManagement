﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace UniversityManagement.API.Models
{
	public class Enrollment
	{
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }

        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }

    public enum Grade
    {
        A, B, C, D, F
    }
}

