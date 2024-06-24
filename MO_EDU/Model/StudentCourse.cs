using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MO_EDU.Model
{
    public class StudentCourse
    {
        [Key]
        public int StudentCourseID { get; set; }
        [ForeignKey("InstructorID")]
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }  
        [ForeignKey("CourseID")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        public Student Student { get; set; }


    }
}
