using MO_EDU.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MO_EDU.DTO
{
    public class StudentCourseDTO
    {
        public int StudentCourseID { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
    }
}
