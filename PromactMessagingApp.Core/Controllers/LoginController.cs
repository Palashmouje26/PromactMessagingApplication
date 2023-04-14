using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromactMessagingApp.Repository.Login;
using System;
using System.Threading.Tasks;

namespace Promact_Messaging_Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Private Member
        private readonly ILoginRepository _loginRepository;
        #endregion

        #region Constructore
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        #endregion

        #region Public Methods
        /**
        * @api {post}/Login/adduser by method to login .
        * 
        * @apiBody {object} user email and password.
        * 
        * @apiSuccessExample Success-Response:
        *  { 
        *      login = "Xyz@ghk.com",
        *      Password =  "Xyz@123"
        *  }
        */
        [HttpPost("userlogin")]
        public async Task<IActionResult> CreateLoginAsync(string emailId, string passcode)
        {
            var result = await _loginRepository.AddloginUserAsync(emailId, passcode);

            if (result.IsValidate == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Email And Password Enter Incorrect");
            }
            return Ok("Login Successfully");
        }

        /**
        * @api {get} /api/Login/all active user information show.
        * @apiName GetActuveUserDetailAsync.
        * @apiGroup login
        *    
        *  @apiSuccess : List Of active user details.
        *  
        * @apiSuccessExample Success-Response:{object[]} :
        * 
        */
        [HttpGet("activeuser")]
        public async Task<IActionResult> GetActiveUserDetailAsync()
        {
            return Ok(await _loginRepository.GetActiveUserAsync());
        }

        #endregion
    }
}
