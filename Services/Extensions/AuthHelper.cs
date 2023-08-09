using Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class AuthHelper
    {
        public static string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretsecretsecretsecretsecretsecretsecret"));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var authClaims = new List<Claim>()
            {
                         new Claim(ClaimTypes.Name,user.UserName),
                         new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                         new Claim(ClaimTypes.Role, user.UserRoles?.FirstOrDefault()?.Role?.Name),
                         new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };


            var token = new JwtSecurityToken(
                issuer: "sanctionscanner.com",
                audience: "sanctionscanner.com",
                //expires: DateTime.Now.AddHours(6),
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: signInCredentials
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

        public static string GenareteBasicAuthToken(string token)
        {
            var textBytes = Encoding.UTF8.GetBytes(token);
            return Convert.ToBase64String(textBytes);
        }
    }
}
