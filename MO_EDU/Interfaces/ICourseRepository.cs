using MO_EDU.Model;

namespace MO_EDU.Interfaces
{
    public interface ICourseRepository
    {
        ICollection<Course> GetCourse();
        Course GetCourseById(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
    }
}