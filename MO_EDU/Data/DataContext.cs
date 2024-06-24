using Microsoft.EntityFrameworkCore;
using MO_EDU.Model;

namespace MO_EDU.Data
{
    public class DataContext : DbContext
    {
        public  DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<InstructorCourse> InstructorCourses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }


    }
}
