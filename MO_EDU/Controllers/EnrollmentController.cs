using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MO_EDU.DTO;
using MO_EDU.DTOs;
using MO_EDU.Interfaces;
using MO_EDU.Model;
using MO_EDU.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MO_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEnrollments()
        {
            try
            {
                var enrollments = _mapper.Map<IEnumerable<EnrollmentDTO>>(_enrollmentRepository.GetEnrollments());
                return Ok(enrollments);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve enrollments: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEnrollment(int id)
        {

            try
            {
                var enrollment = _enrollmentRepository.GetEnrollmentById(id);
                if (enrollment == null)
                {
                    return NotFound($"Enrollment with ID {id} not found");
                }
                var enrollmentDTO = _mapper.Map<EnrollmentDTO>(enrollment);
                return Ok(enrollmentDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve enrollment: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult PostEnrollment(EnrollmentDTO enrollmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollment = _mapper.Map<Enrollment>(enrollmentDTO);
            _enrollmentRepository.AddEnrollment(enrollment);
            return CreatedAtAction("GetEnrollment", new { id = enrollment.EnrollmentID }, new EnrollmentDTO()
            {
                EnrollmentID = enrollment.EnrollmentID,
                Role = enrollment.role,
                UserID = enrollment.UserID
            });

        }
    }
}
