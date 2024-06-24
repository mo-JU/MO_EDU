using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MO_EDU.DTO;
using MO_EDU.Interfaces;
using MO_EDU.Model;
using MO_EDU.Repository;
using System.ComponentModel.DataAnnotations;

namespace MO_EDU.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]

    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            this._courseRepository = courseRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCourse()
        {
            var courses = _mapper.Map<IEnumerable<CourseDTO>>(_courseRepository.GetCourse());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(courses);
        }

        [HttpGet("{CourseID}")]
        public IActionResult GetCourse(int CourseID)
        {
            var course = _mapper.Map<CourseDTO>(_courseRepository.GetCourseById(CourseID));

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = _mapper.Map<Course>(courseDTO);
            course.creationDate = DateTime.Now;

            _courseRepository.AddCourse(course);

            return CreatedAtAction("GetCourse", new { id = course.CourseID }, course);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }


            _courseRepository.DeleteCourse(course);

            return NoContent();
        }

    }
}

