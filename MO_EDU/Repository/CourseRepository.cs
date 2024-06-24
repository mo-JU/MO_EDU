using MO_EDU.Data;
using MO_EDU.Interfaces;
using MO_EDU.Model;

namespace MO_EDU.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;
        public CourseRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Course> GetCourse()
        {
            return _context.Courses.OrderBy(p => p.CourseID).ToList();
        }
        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(e => e.CourseID == id);
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }


        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}
