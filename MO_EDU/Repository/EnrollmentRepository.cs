using Microsoft.EntityFrameworkCore;
using MO_EDU.Data;
using MO_EDU.DTO;
using MO_EDU.DTOs;
using MO_EDU.Interfaces;
using MO_EDU.Model;

namespace MO_EDU.Repository
{
    public class EnrollmentRepository: IEnrollmentRepository
    {
        private readonly DataContext _context;
        public EnrollmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Enrollment> GetEnrollmentByUserId(int userId)
        {
            return await _context.Enrollments
                .FirstOrDefaultAsync(e => e.UserID == userId);
        }
        public ICollection<Enrollment> GetEnrollments()
        {
            return _context.Enrollments.OrderBy(p => p.EnrollmentID).ToList();
        }
        public Enrollment GetEnrollmentById(int id)
        {
            return _context.Enrollments.FirstOrDefault(e => e.EnrollmentID == id);
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }


        public void UpdateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }

        public void DeleteEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
        }
    }
}
