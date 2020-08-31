using System;
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


        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("test")]
        public IActionResult Test()
        {
            string token = "only superadmin sees this";
            return Ok(new { token });
        }



        // POST: api/user/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult AuthenticateUser([FromBody] AuthenticateModel model)
        {
            var user = _userLogic.AuthenticateUser(model);

            if (user == null)
                return BadRequest(ErrorDetails.SetError(StatusCodes.Status400BadRequest, "Username or password is incorrect"));

            string token = _userLogic.GenerateJWT(user);
            return Ok(new { token });
        }
    }
}
