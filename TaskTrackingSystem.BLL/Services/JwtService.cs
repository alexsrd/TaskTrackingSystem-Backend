using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TaskTrackingSystem.BLL.Services.Interfaces;

namespace TaskTrackingSystem.BLL.Services
{
    public class JwtService : IJwtService
    {
        private readonly double _jwtExpireDays;
        private readonly string _jwtIssuer;
        private readonly byte[] _jwtKey;

        public JwtService(string jwtKey, double jwtExpireDays, string jwtIssuer)
        {
            _jwtKey = Encoding.UTF8.GetBytes(jwtKey);
            _jwtExpireDays = jwtExpireDays;
            _jwtIssuer = jwtIssuer;
        }

        public string GenerateJwtToken(string id)
        {
            var claims = new List<Claim>
            {
                new Claim("UserID", id)
            };

            var key = new SymmetricSecurityKey(_jwtKey);
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_jwtExpireDays);

            var token = new JwtSecurityToken(
                _jwtIssuer,
                _jwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}