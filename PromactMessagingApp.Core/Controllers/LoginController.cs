using Microsoft.AspNetCore.Mvc;
using PromactMessagingApp.Repository.Login;
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
        * @api {post}/login/:emailId And password Is used for login the user.
        * 
        * @apiParam {Number} emailId is unique emailId of user.
        * @apiParam {String} password is unique password of user.
        * 
        * @apiBody {object} user email and password.
        * 
        * @apiSuccessExample Success-Response: showing list of active user.
        */
        [HttpGet("userlogin")]
        public async Task<IActionResult> CreateLoginAsync(string emailId, string password)
        {
            var result = await _loginRepository.AddLoginUserAsync(emailId, password);
            if (result.IsValidate)
            {
                return Redirect("https://localhost:44318/api/Login/activeuser");
            }
            else
            {
                return BadRequest();
            }
        }

        /**
        * @api {get} /login/ list of all active user information show.
        * @apiName GetActuveUserDetailAsync.
        * @apiGroup login
        *    
        * @apiSuccess :  Showing List Of active user details.
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
