using MO_EDU.Model;

namespace MO_EDU.Interfaces
{
    public interface IStudentCourseRepository
    {
        ICollection<StudentCourse> GetStudentCourse();
        StudentCourse GetStudentCourseById(int id);
        void AddStudentCourse(StudentCourse studentCourse);
        void UpdateStudentCourse(StudentCourse studentCourse);
        void DeleteStudentCourse(StudentCourse studentCourse);
    }
}