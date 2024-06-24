using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MO_EDU.DTO;
using MO_EDU.Interfaces;
using MO_EDU.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Http.ModelBinding;

namespace MO_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User user = new User();
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public UserController(IUserRepository userRepository, IConfiguration configuration, IEnrollmentRepository enrollmentRepository)
        {
            this._userRepository = userRepository;
            this._configuration = configuration;
            this._enrollmentRepository = enrollmentRepository;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.creationDate = DateTime.Now;


            await _userRepository.AddUser(user);
            await _userRepository.SaveAsync();


            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {

            var user = await _userRepository.Login(request);

            if (user is null)
                return BadRequest("user not found");


            var enrollment = await _enrollmentRepository.GetEnrollmentByUserId(user.UserID);

            // Extract role information
            var role = enrollment?.role; // Assuming Role is a property of Enrollment

            // Create token with role claim
            string token = CreateToken(user, role);
            return Ok(token);

        }

        private string CreateToken(User user, int? role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.userName),
                new Claim(ClaimTypes.Role,"1")
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(_configuration.GetSection("Appsettings:Token").Value
                        ));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            var existingUser = await _userRepository.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.userName = user.userName;
            existingUser.email = user.email;
            existingUser.password = user.password;


            _userRepository.UpdateUser(existingUser);
            await _userRepository.SaveAsync();


            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }


            _userRepository.DeleteUser(user);
            await _userRepository.SaveAsync();

            return NoContent();
        }
    }
}
