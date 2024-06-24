using MO_EDU.Data;
using MO_EDU.Interfaces;
using MO_EDU.Model;

namespace MO_EDU.Repository
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly DataContext _context;
        public StudentCourseRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<StudentCourse> GetStudentCourse()
        {
            return _context.StudentCourses.OrderBy(p => p.StudentCourseID).ToList();
        }
        public StudentCourse GetStudentCourseById(int id)
        {
            return _context.StudentCourses.FirstOrDefault(e => e.StudentCourseID == id);
        }

        public void AddStudentCourse(StudentCourse studentCourse)
        {
            _context.StudentCourses.Add(studentCourse);
            _context.SaveChanges();
        }


        public void UpdateStudentCourse(StudentCourse studentCourse)
        {
            _context.StudentCourses.Update(studentCourse);
            _context.SaveChanges();
        }

        public void DeleteStudentCourse(StudentCourse studentCourse)
        {
            _context.StudentCourses.Remove(studentCourse);
            _context.SaveChanges();
        }
    }
}
