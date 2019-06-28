using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("api/login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Invalid request");

            if (user.Username == "Jack" && user.Password == "123456")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken
                (
                  issuer: "http://localhost:5000",
                  audience: "http://localhost:5000",
                  claims: new List<Claim>(),
                  expires: DateTime.Now.AddHours(10),
                  signingCredentials: signInCredentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new
                {
                    token = token
                });
            }

            return Unauthorized();
        }
    }
}
