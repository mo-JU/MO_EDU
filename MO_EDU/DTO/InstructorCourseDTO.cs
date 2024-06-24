using MO_EDU.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MO_EDU.DTO
{
    public class InstructorCourseDTO
    {
        public int InstructorCourseID { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
    }
}
