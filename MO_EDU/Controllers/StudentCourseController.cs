using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MO_EDU.DTO;
using MO_EDU.Interfaces;
using MO_EDU.Model;
using MO_EDU.Repository;

namespace MO_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IMapper _mapper;

        public StudentCourseController(IStudentCourseRepository studentCourseRepository, IMapper mapper)
        {
            this._studentCourseRepository = studentCourseRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetStudentCourse()
        {
            var studentCourses = _mapper.Map<IEnumerable<StudentCourseDTO>>(_studentCourseRepository.GetStudentCourse());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(studentCourses);
        }

        [HttpGet("{StudentCourseID}")]
        public IActionResult GetStudentCourse(int StudentCourseID)
        {
            var studentCourse = _mapper.Map<StudentCourseDTO>(_studentCourseRepository.GetStudentCourseById(StudentCourseID));

            if (studentCourse == null)
                return NotFound();

            return Ok(studentCourse);
        }

        [HttpPost]
        public async Task<ActionResult<StudentCourse>> PostStudentCourse(StudentCourseDTO studentCourseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentCourse = _mapper.Map<StudentCourse>(studentCourseDTO);

            _studentCourseRepository.AddStudentCourse(studentCourse);

            return CreatedAtAction("GetStudentCourse", new { id = studentCourse.StudentCourseID }, studentCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentCourse(int id)
        {
            var studentCourse = _studentCourseRepository.GetStudentCourseById(id);
            if (studentCourse == null)
            {
                return NotFound();
            }


            _studentCourseRepository.DeleteStudentCourse(studentCourse);

            return NoContent();
        }

    }
}