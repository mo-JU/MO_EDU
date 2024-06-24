using MO_EDU.Data;
using MO_EDU.Interfaces;
using MO_EDU.Model;

namespace MO_EDU.Repository
{
    public class InstructorCourseRepository : IInstructorCourseRepository
    {
        private readonly DataContext _context;
        public InstructorCourseRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<InstructorCourse> GetInstructorCourse()
        {
            return _context.InstructorCourses.OrderBy(p => p.InstructorCourseID).ToList();
        }
        public InstructorCourse GetInstructorCourseById(int id)
        {
            return _context.InstructorCourses.FirstOrDefault(e => e.InstructorCourseID == id);
        }

        public void AddInstructorCourse(InstructorCourse instructorCourse)
        {
            _context.InstructorCourses.Add(instructorCourse);
            _context.SaveChanges();
        }


        public void UpdateInstructorCourse(InstructorCourse instructorCourse)
        {
            _context.InstructorCourses.Update(instructorCourse);
            _context.SaveChanges();
        }

        public void DeleteInstructorCourse(InstructorCourse instructorCourse)
        {
            _context.InstructorCourses.Remove(instructorCourse);
            _context.SaveChanges();
        }
    }
}
