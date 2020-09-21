using BugTracker.Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BugTracker.Data.Helpers
{
   public class JWTFactory : IJWTFactory
    {
        private readonly JWTSettings _jwtSettings;
        public JWTFactory(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;   
        }

        /// <summary>
        /// Generates JWT token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string GenerateJWT(UserModel userInfo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var claims = new List<Claim>
            {
                new Claim("userid", userInfo.UserId.ToString()),
                new Claim("username", userInfo.FirstName + " " + userInfo.LastName)
            };

            claims.AddRange(userInfo.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddDays(_jwtSettings.DurationDays)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public interface IJWTFactory
    {
        string GenerateJWT(UserModel userInfo);
    }

    /// <summary>
    /// Define JWT Settings
    /// </summary>
    public class JWTSettings
    {
        public string Secret { get; set; }
        public int DurationDays { get; set; }
    }
}
