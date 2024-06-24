using MO_EDU.Data;
using MO_EDU.Interfaces;
using MO_EDU.Model;

namespace MO_EDU.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly DataContext _context;
        public InstructorRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Instructor> GetInstructor()
        {
            return _context.Instructors.OrderBy(p => p.InstructorID).ToList();
        }
        public Instructor GetInstructorById(int id)
        {
            return _context.Instructors.FirstOrDefault(e => e.InstructorID == id);
        }

        public void AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }


        public void UpdateInstructor(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            _context.SaveChanges();
        }

        public void DeleteInstructor(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
        }
    }
}