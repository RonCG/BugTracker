using BugTracker.Data.Helpers;
using BugTracker.Data.Models;
using BugTracker.Data.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BugTracker.Logic.Logic
{
    /// <summary>
    /// Manage user logic
    /// </summary>
    public class UserLogic : IUserLogic
    {
        private readonly IUnitOfWork db;
        private readonly JWTSettings _jwtSettings;

        public UserLogic(IUnitOfWork unitOfWork, IOptions<JWTSettings> jwtSettings)
        {
            db = unitOfWork;
            _jwtSettings = jwtSettings.Value;
        }



        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserModel AuthenticateUser(AuthenticateModel request)
        {
            if (request.Username != "Ronny" || request.Password != "1234")
                return null;

            return new UserModel
            {
                FirstName = "Ronny",
                LastName = "Cordova",
                RoleName = "Admin",
                UserId = 1858
            };
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
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userid", userInfo.UserId.ToString()),
                    new Claim("firstname", userInfo.FirstName),
                    new Claim("lastname",userInfo.LastName),
                    new Claim("username", userInfo.UserName),
                    new Claim(ClaimTypes.Role, userInfo.RoleName.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }



    /// <summary>
    /// IUserLogic DI Inteface
    /// </summary>
    public interface IUserLogic
    {
        //IEnumerable<UserModel> GetUsers();
        UserModel AuthenticateUser(AuthenticateModel request);
        string GenerateJWT(UserModel userInfo);
    }
}
