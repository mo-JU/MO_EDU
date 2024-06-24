using MO_EDU.Model;

namespace MO_EDU.Interfaces
{
    public interface IInstructorRepository
    {
        ICollection<Instructor> GetInstructor();
        Instructor GetInstructorById(int id);
        void AddInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
        void DeleteInstructor(Instructor instructor);
    }
}