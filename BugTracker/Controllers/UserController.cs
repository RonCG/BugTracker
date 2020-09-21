﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data.Helpers;
using BugTracker.Data.Models;
using BugTracker.Logic.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Web.Controllers
{
    /// <summary>
    /// User controller endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }


        // POST: api/user/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult AuthenticateUser([FromBody] AuthenticateModel model)
        {
            var jwtToken = _userLogic.AuthenticateUser(model);

            if (jwtToken == string.Empty)
                return BadRequest(ErrorDetails.SetError(StatusCodes.Status400BadRequest, "Username or password is incorrect"));

            return Ok(new { jwtToken });
        }



        [AllowAnonymous]
        [HttpPost("resetpassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel data)
        {
            var result = _userLogic.ResetPassword(data);
            if(result)
                return Ok(result); 

            return BadRequest(ErrorDetails.SetError(StatusCodes.Status400BadRequest, "Something went wrong. Please try again"));
        }



        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel user)
        {
            return Ok(_userLogic.CreateNew(user));
        }
    }
}
