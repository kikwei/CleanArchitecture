using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ProductsCleanArch.Presentation.Authentication
{
    public class JwtAuthentication : IJwtAuthentication
    {
        private readonly IConfiguration _configuration;

        public JwtAuthentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IDictionary<string, string> users = new Dictionary<string, string> { { "user1", "password1" } };
        public string Authenticate(string userName, string password)
        {
            if (users.Any(user => user.Key == userName && user.Value == password))
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, userName)
                };

                var token = new JwtSecurityToken(_configuration["JwtIssuer"],
                 _configuration["JwtIssuer"], claims, expires: DateTime.UtcNow.AddHours(1),
                  signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"])),
                   SecurityAlgorithms.HmacSha256Signature));

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null;
        }
    }
}