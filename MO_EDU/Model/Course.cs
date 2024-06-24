using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MO_EDU.Model
{
    public class Course
    {
        public Course() {
            this.StudentCourses = new HashSet<StudentCourse>();
            this.InstructorCourses = new HashSet<InstructorCourse>();
        }
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        [ForeignKey("AdminId")]
        public int AdminID { get; set; }
        public Admin Admin { get; set; }
        public DateTime creationDate { get; set; }
        public bool isDeleted { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<InstructorCourse> InstructorCourses { get; set; }
    }
}
