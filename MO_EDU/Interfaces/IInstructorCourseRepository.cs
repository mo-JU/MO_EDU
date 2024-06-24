using MO_EDU.Model;

namespace MO_EDU.Interfaces
{
    public interface IInstructorCourseRepository
    {
        ICollection<InstructorCourse> GetInstructorCourse();
        InstructorCourse GetInstructorCourseById(int id);
        void AddInstructorCourse(InstructorCourse instructorCourse);
        void UpdateInstructorCourse(InstructorCourse instructorCourse);
        void DeleteInstructorCourse(InstructorCourse instructorCourse);
    }
}