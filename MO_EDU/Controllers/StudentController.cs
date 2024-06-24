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
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper )
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _mapper.Map<IEnumerable<StudentDTO>>(_studentRepository.GetStudents());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(students);
        }

        [HttpGet("{StudentID}")]
        public IActionResult GetStudent(int StudentID)
        {
            var student = _mapper.Map<StudentDTO>(_studentRepository.GetStudentById(StudentID));

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _mapper.Map<Student>(studentDTO);
            student.creationDate = DateTime.Now;

            await _studentRepository.AddStudent(student);
            await _studentRepository.SaveAsync();

            return CreatedAtAction("GetStudent", new { id = student.StudentID }, student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }


            _studentRepository.DeleteStudent(student);
            await _studentRepository.SaveAsync();

            return NoContent();
        }

    }
}
        