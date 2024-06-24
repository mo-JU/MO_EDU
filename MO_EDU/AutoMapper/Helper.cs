using AutoMapper;
using MO_EDU.DTO;
using MO_EDU.DTOs;
using MO_EDU.Model;

namespace MO_EDU.AutoMapper
{
    public class Helper :Profile
    {
        public Helper() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Student,StudentDTO>();
            CreateMap<StudentDTO,Student>();
            CreateMap<Enrollment,EnrollmentDTO>();
            CreateMap<EnrollmentDTO,Enrollment>();
            CreateMap<Instructor,InstructorDTO>();
            CreateMap<InstructorDTO,Instructor>();
            CreateMap<Admin,AdminDTO>();
            CreateMap<AdminDTO,Admin>();
            CreateMap<CourseDTO,Course>();
            CreateMap<Course,CourseDTO>();
            CreateMap<StudentCourse,StudentCourseDTO>();
            CreateMap<StudentCourseDTO,StudentCourse>();
            CreateMap<InstructorCourse,InstructorCourseDTO>();
            CreateMap<InstructorCourseDTO,InstructorCourse>();
        }
    }
}
