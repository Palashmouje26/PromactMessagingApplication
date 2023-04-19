using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromactMessagingApp.DomainModel.ApplicationClasses.UserAC;
using PromactMessagingApp.Repository.User;
using System;
using System.Threading.Tasks;

namespace Promact_Messaging_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region private Member
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructor
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region public Methods

       /**
       * @api {get} /userInformation/:all user information.
       * @apiName GetUserDetailAsync
       * @apiGroup User
       *    
       * @apiSuccess :Showing list Of user details.
       *  
       * @apiSuccessExample Success-Response:{object[]}
       * 
       */
        [HttpGet("userdetail")]
        public async Task<IActionResult> GetUserDetailAsync()
        {
            return Ok(await _userRepository.GetAllUserDetailAsync());
        }

       /**
       * @api {get}/userInformation/:id get one particuler user information.
       * @apiName GetUserByIDAsync.
       * @apiGroup User
       *    
       * @apiParam {Number}  Id of the user.
       * 
       * @apiSuccess :show particuler user details.
       */
        [HttpGet("userbyId/{Id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] string Id)
        {
            return Ok(await _userRepository.GetUserByIdAsync(Id));
        }

        /**
        *   @api {post}/ userInformation/:adduser Method to add user detail.
        *   
        *   @apiParam {String} UserAC Object.
        *   @apiBody {object} user detail.
        *   
        *   @apiSuccess : Success-Response:{object[]} 
        */
        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUserAsync([FromForm] UserAC user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _userRepository.AddUserAsync(user);

            return Ok("Created Successfully");
        }

        /**
         * @api {put} /userInformation/:updating user information.
         * @apiName UpdateUserAsync.
         * @apiGroup User
         *
         * @apiParam {String} UserAC Object.
         * 
         * @apiErrorExample Error-Response: BadRequest.
         */
        [HttpPut("updateuserdetail")]
        public async Task<ActionResult> UpdateUserAsync([FromForm] UserAC userDetail)
        {
            if (userDetail.Id == null)
            {
                return BadRequest();
            }
            await _userRepository.UpdateUserDetailAsync(userDetail);
            return Ok("Update Information Successfully");
        }

        /**
        * @api {put} / userInformation/:updating user status.
        * 
        * @apiName UpdateUserByIdAsync
        * @apiGroup User
        * 
        * @apiParam :Id of the user is used.
        * 
        * @apiSuccessExample Success-Response:{object[]} 
        */
        [HttpPut("updateuserstatusbyId/{Id}")]
        public async Task<ActionResult> UpdateUserStatusByIdAsync([FromRoute] string Id)
        {
            await _userRepository.UpdateUserStatusByIdAsync(Id);
            return Ok("Update status Successfully");
        }
        #endregion
    }
}
