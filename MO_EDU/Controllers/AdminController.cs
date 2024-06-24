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
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminController(IAdminRepository adminRepository, IMapper mapper)
        {
            this._adminRepository = adminRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAdmin()
        {
            var admins = _mapper.Map<IEnumerable<AdminDTO>>(_adminRepository.GetAdmin());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(admins);
        }

        [HttpGet("{AdminID}")]
        public IActionResult GetAdmin(int AdminID)
        {
            var admin = _mapper.Map<AdminDTO>(_adminRepository.GetAdminById(AdminID));

            if (admin == null)
                return NotFound();

            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(AdminDTO adminDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var admin = _mapper.Map<Admin>(adminDTO);
            admin.creationDate = DateTime.Now;

            _adminRepository.AddAdmin(admin);

            return CreatedAtAction("GetAdmin", new { id = admin.AdminID }, admin);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = _adminRepository.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }


            _adminRepository.DeleteAdmin(admin);

            return NoContent();
        }

    }
}
