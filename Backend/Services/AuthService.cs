using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services
{
    public class AuthService : IAuthService
    {
        public TokenModel Login(User user)
        {
            if (user.Username == "Jack" && user.Password == "123456")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123"));
                var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var tokenOptions = new JwtSecurityToken
                (
                  issuer: "http://localhost:5000",
                  audience: "http://localhost:5000",
                  claims: claims,
                  expires: DateTime.Now.AddHours(10),
                  signingCredentials: signInCredentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return new TokenModel
                {
                    Token = token
                };
            }

            return null;
        }
    }
}