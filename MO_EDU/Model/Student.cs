using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MO_EDU.Model
{
    public class Student
    {
        public Student() {
            this.StudentCourses = new HashSet<StudentCourse>();
        }
        [Key]
        public int StudentID { get; set; }
        public string studentName { get; set; }
        public int age { get; set; }
        [ForeignKey("EnrollmentId")]
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
        public bool gender { get; set; }
        public string contactInformation { get; set; }
        public DateTime creationDate { get; set; }
        public bool isDeleted { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
