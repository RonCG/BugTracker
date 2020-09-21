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
        private readonly IUnitOfWork _repositories;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;

        public UserLogic(IOptions<JWTSettings> jwtSettings, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IEmailService emailService)
        {
            _jwtSettings = jwtSettings.Value;
            _repositories = unitOfWork;
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
            UserModel userDetail = null;
            var user = _repositories.Users.Find(x => x.UserName == request.Username && x.StatusId == UserStatus.Active).FirstOrDefault();     
            if (user != null)
            {
                var (Verified, NeedsUpgrade) = _passwordHasher.Check(user.Password, request.Password);
                if (Verified)                
                    userDetail = _repositories.Users.GetUserDetail(user.UserId);                 
            }

            return userDetail;
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



        public bool ResetPassword(ResetPasswordModel data)
        {
            bool retVal = false;
            var passwordRequest = _repositories.PasswordRequest.GetPasswordRequest(data);
            if (passwordRequest != null)
            {
                User user = _repositories.Users.Get(passwordRequest.UserId); 
                if(user != null)
                {
                    user.Password = _passwordHasher.Hash(data.NewPassword);
                    if (user.StatusId == UserStatus.Pending)
                        user.StatusId = UserStatus.Active;
                   
                    _repositories.Users.Update(user);

                    passwordRequest.Active = false;
                    _repositories.PasswordRequest.Update(passwordRequest);

                    _repositories.SaveChanges();
                    retVal = true;
                }
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
                Password = string.Empty,
                Userrole = user.Roles.Select(x => _repositories.Users.SetCreateVars(new Userrole { RoleId = x.RoleId })).ToList()
            };

            _repositories.Users.Add(newUser);
            _repositories.SaveChanges();
            user.UserId = newUser.UserId;

            Passwordrequest passwordRequest = new Passwordrequest
            {
                UserId = user.UserId,
                Token = Guid.NewGuid().ToString(),
                Active = true
            };

            _repositories.PasswordRequest.Add(passwordRequest);
            _repositories.SaveChanges();

            _emailService.Send("***REMOVED***", user.Email, "Invite Test", "Hello!");

            return user;
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
