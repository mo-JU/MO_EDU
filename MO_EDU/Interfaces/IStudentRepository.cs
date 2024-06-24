using MO_EDU.Model;

namespace MO_EDU.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
        Task<Student> GetStudentById(int id);
        Task AddStudent(Student student);
        Task SaveAsync();
        Task UpdateStudent(Student student);
        Task DeleteStudent(Student student);
    }
}
