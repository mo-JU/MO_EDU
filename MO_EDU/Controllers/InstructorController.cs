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
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public InstructorController(IInstructorRepository instructorRepository, IMapper mapper)
        {
            this._instructorRepository = instructorRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetInstructor()
        {
            var instructors = _mapper.Map<IEnumerable<InstructorDTO>>(_instructorRepository.GetInstructor());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(instructors);
        }

        [HttpGet("{InstructorID}")]
        public IActionResult GetInstructor(int InstructorID)
        {
            var instructor = _mapper.Map<InstructorDTO>(_instructorRepository.GetInstructorById(InstructorID));

            if (instructor == null)
                return NotFound();

            return Ok(instructor);
        }

        [HttpPost]
        public async Task<ActionResult<Instructor>> PostInstructor(InstructorDTO instructorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var instructor = _mapper.Map<Instructor>(instructorDTO);
            instructor.creationDate = DateTime.Now;

            _instructorRepository.AddInstructor(instructor);

            return CreatedAtAction("GetInstructor", new { id = instructor.InstructorID }, instructor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var instructor =  _instructorRepository.GetInstructorById(id);
            if (instructor == null)
            {
                return NotFound();
            }


            _instructorRepository.DeleteInstructor(instructor);

            return NoContent();
        }

    }
}
