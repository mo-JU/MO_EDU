using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MO_EDU.Model
{
    public class InstructorCourse
    {
        
        [Key]
        public int InstructorCourseID { get; set; }
        [ForeignKey("InstructorId")]
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
        [ForeignKey("CourseId")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
