using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MO_EDU.Model
{
    public class Instructor
    {
        public Instructor() 
        {
            this.StudentCourses = new HashSet<StudentCourse>();
            this.InstructorCourses = new HashSet<InstructorCourse>();
        }

        [Key]
        public int InstructorID { get; set; }
        public string instructorName { get; set; }
        public int age { get; set; }
        public bool gender { get; set; }
        [ForeignKey("EnrollmentID")]
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
        public string contactInformation { get; set; }
        public string specialization_subject { get; set; }
        public DateTime creationDate { get; set; }
        public bool isDeleted { get; set; }
        [ForeignKey("AdminID")]
        public int AdminID { get; set; }
        public Admin Admin { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<InstructorCourse> InstructorCourses { get; set; }
    }
}
