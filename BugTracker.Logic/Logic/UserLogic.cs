using BugTracker.Data;
using BugTracker.Data.Helpers;
using BugTracker.Data.Models;
using BugTracker.Data.Repositories;
using System;
using System.Linq;


namespace BugTracker.Logic.Logic
{
    /// <summary>
    /// Manage user logic
    /// </summary>
    public class UserLogic : IUserLogic
    {
        private readonly IJWTFactory _jwtFactory;
        private readonly IUnitOfWork _repositories;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;

        public UserLogic(IJWTFactory jwtFactory, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IEmailService emailService)
        {
            _jwtFactory = jwtFactory;
            _repositories = unitOfWork;
            _passwordHasher = passwordHasher;
            _emailService = emailService;         
        }



        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string AuthenticateUser(AuthenticateModel request)
        {
            string jwtToken = string.Empty;
            var user = _repositories.Users.Find(x => x.UserName == request.Username).FirstOrDefault();
            if (user != null)
            {
                var (Verified, NeedsUpgrade) = _passwordHasher.Check(user.Password, request.Password);
                if (Verified)
                    jwtToken = _jwtFactory.GenerateJWT(_repositories.Users.GetUserDetail(user.UserId));
            }

            return jwtToken;
        }


        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

            _emailService.Send("ronny1612695@gmail.com", user.Email, "Invite Test", "Hello!");

            return user;
        }



        /// <summary>
        /// Sends a reset password email to a user 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool ForgotPassword(string username)
        {
            bool retVal = false;

            var user = _repositories.Users.GetUserByUsername(username);
            if(user != null)
            {               
                Passwordrequest passwordRequest = new Passwordrequest
                {
                    UserId = user.UserId,
                    Token = Guid.NewGuid().ToString(),
                    Active = true
                };

                _repositories.PasswordRequest.Add(passwordRequest);
                _repositories.SaveChanges();

                //send mail
                _emailService.Send("ronny1612695@gmail.com", user.Email, "Forgot password", "Hello!");

                retVal = true;
            }
            return retVal;
        }



        /// <summary>
        /// Resets a user password
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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

    }



    /// <summary>
    /// IUserLogic DI Inteface
    /// </summary>
    public interface IUserLogic
    {
        string AuthenticateUser(AuthenticateModel request);
        UserModel CreateNew(UserModel user);
        bool ForgotPassword(string username);
        bool ResetPassword(ResetPasswordModel data);
    }
}
