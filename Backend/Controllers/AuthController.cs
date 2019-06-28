using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }

        [HttpPost("api/login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Invalid request");

            var token = service.Login(user);

            if (token != null)
                return Ok(token);

            return Unauthorized();
        }
    }
}
