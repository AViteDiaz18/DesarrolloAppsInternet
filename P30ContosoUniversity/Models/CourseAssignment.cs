using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContosoUniversity.Models
{
    public class CourseAssignment
    {
        [Key]
        public int CourseID {get; set;}
        public int InstructorID {get; set;}
        public Course Course {get; set;}
        public Instructor Instructor {get; set;}
        
    }
}