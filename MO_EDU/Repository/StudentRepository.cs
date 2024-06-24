using Microsoft.EntityFrameworkCore;
using MO_EDU.Data;
using MO_EDU.Interfaces;
using MO_EDU.Model;

namespace MO_EDU.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly DataContext _context;
        public StudentRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Student> GetStudents()
        {
            return _context.Students.OrderBy(p => p.StudentID).ToList();
        }
        public async Task AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStudent(Student student)
        {
            _context.Students.Update(student);
        }
        public async Task<Student> GetStudentById(int id) => 
            await _context.Students.AsNoTracking().FirstOrDefaultAsync(w =>w.StudentID == id);

        public async Task DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}
