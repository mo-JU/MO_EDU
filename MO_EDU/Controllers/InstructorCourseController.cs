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
    public class InstructorCourseController : ControllerBase
    {
        private readonly IInstructorCourseRepository _studentCourseRepository;
        private readonly IMapper _mapper;

        public InstructorCourseController(IInstructorCourseRepository studentCourseRepository, IMapper mapper)
        {
            this._studentCourseRepository = studentCourseRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetInstructorCourse()
        {
            var studentCourses = _mapper.Map<IEnumerable<InstructorCourseDTO>>(_studentCourseRepository.GetInstructorCourse());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(studentCourses);
        }

        [HttpGet("{InstructorCourseID}")]
        public IActionResult GetInstructorCourse(int InstructorCourseID)
        {
            var studentCourse = _mapper.Map<InstructorCourseDTO>(_studentCourseRepository.GetInstructorCourseById(InstructorCourseID));

            if (studentCourse == null)
                return NotFound();

            return Ok(studentCourse);
        }

        [HttpPost]
        public async Task<ActionResult<InstructorCourse>> PostInstructorCourse(InstructorCourseDTO studentCourseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentCourse = _mapper.Map<InstructorCourse>(studentCourseDTO);

            _studentCourseRepository.AddInstructorCourse(studentCourse);

            return CreatedAtAction("GetInstructorCourse", new { id = studentCourse.InstructorCourseID }, studentCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructorCourse(int id)
        {
            var studentCourse = _studentCourseRepository.GetInstructorCourseById(id);
            if (studentCourse == null)
            {
                return NotFound();
            }


            _studentCourseRepository.DeleteInstructorCourse(studentCourse);

            return NoContent();
        }

    }
}
