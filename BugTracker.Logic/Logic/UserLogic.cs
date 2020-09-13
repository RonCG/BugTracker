using BugTracker.Data;
using BugTracker.Data.Helpers;
using BugTracker.Data.Models;
using BugTracker.Data.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BugTracker.Logic.Logic
{
    /// <summary>
    /// Manage user logic
    /// </summary>
    public class UserLogic : IUserLogic
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IUnitOfWork _db;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;

        public UserLogic(IOptions<JWTSettings> jwtSettings, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IEmailService emailService)
        {
            _jwtSettings = jwtSettings.Value;
            _db = unitOfWork;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
        }



        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserModel AuthenticateUser(AuthenticateModel request)
        {
            UserModel retVal = null;
            User user = _db.Users.Find(x => x.UserName == request.Username).FirstOrDefault();
            if(user != null && user.StatusId == UserStatus.Active)
            {
                var (Verified, NeedsUpgrade) = _passwordHasher.Check(user.Password, request.Password);
                if (Verified)
                    retVal = (UserModel)user;
            }

            return retVal;
            //if (request.Username != "Ronny" || request.Password != "1234")
            //    return null;
            //return new UserModel
            //{
            //    FirstName = "Ronny",
            //    LastName = "Cordova",
            //    Roles = new List<string> { "Admin", "SuperAdmin" },
            //    UserId = 1858
            //};
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

            claims.AddRange(userInfo.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddDays(_jwtSettings.DurationDays)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        public bool ResetPassword(ResetPasswordModel data)
        {
            bool retVal = false;
            //if requestID exists...
            if (true)
            {
                User currentUser = new User(); //get the request record and get the userID from there...
                currentUser.Password = _passwordHasher.Hash(data.NewPassword);
                if (currentUser.StatusId == UserStatus.Pending)
                    currentUser.StatusId = UserStatus.Active;

                _db.Users.Update(currentUser);

                //set the request as inactive also...
                _db.Complete();

                retVal = true;
            }

            return retVal;
        }



        public UserModel CreateNew(UserModel user)
        {
            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                StatusId = UserStatus.Pending,
                Password = string.Empty
            };

            _db.Users.Add(newUser);
            _db.Complete();

            _emailService.Send("***REMOVED***", newUser.Email, "Invite Test", "Hello!");            
 
            return (UserModel)newUser;
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
        UserModel CreateNew(UserModel user);
        bool ResetPassword(ResetPasswordModel data);
    }
}
