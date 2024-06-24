using MO_EDU.DTO;
using MO_EDU.DTOs;
using MO_EDU.Model;

namespace MO_EDU.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment> GetEnrollmentByUserId(int userId);
        ICollection<Enrollment> GetEnrollments();
        Enrollment GetEnrollmentById(int id);
        void AddEnrollment(Enrollment enrollment);
        void UpdateEnrollment(Enrollment enrollment);
        void DeleteEnrollment(Enrollment enrollment);
    }
}
