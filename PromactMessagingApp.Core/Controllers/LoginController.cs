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
       * @api {post} /Login/
       * @apiBody {String} UserId      Mandatory UserId of the .
       * @apiBody {String} EmailId     Mandatory  input with small letter"pa".
       * @apiBody {String} Password    Mandatory input 10 digit or number with combination with aplphabets.
       * @apiBody {bool} IsDeleted     User is Active or Not.
       * @apiSuccessExample Success-Response:
       *  { 
       *      login = "Xyz@ghk.com",
       *      Password =  "Xyz@123"
       *  }
       */
        [HttpPost("userlogin")]
        public async Task<IActionResult> AddLoginAsync(string emailId, string passcode)
        {
            var result = await _loginRepository.AddloginUserAsync(emailId, passcode);

            if (result.IsValidate == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Email And Password Enter Incorrect");
            }
            return Ok("Login Successfully");
        }

        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [HttpGet("activeuser")]
        public async Task<IActionResult> GetUserDetailAsync()
        {
            return Ok(await _loginRepository.GetActiveUserAsync());
        }



        #endregion
    }
}
