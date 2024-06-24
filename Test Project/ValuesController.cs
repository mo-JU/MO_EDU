using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            string users = "";

            if (!ModelState.IsValid)
                //    return BadRequest(ModelState);

                return Ok(users);

            return BadRequest();
        }
    }
}
