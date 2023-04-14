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
       * @api {get} /api/UserInformation/all user information.
       * @apiName GetUserDetailAsync
       * @apiGroup User
       *    
       *  @apiSuccess : List Of  user details.
       *  
       * @apiSuccessExample Success-Response:{object[]}  :
       * 
       */
        [HttpGet("userdetail")]
        public async Task<IActionResult> GetUserDetailAsync()
        {
            return Ok(await _userRepository.GetAllUserDetailAsync());
        }
       /**
       * @api {get} /api/UserInformation /:id get one particuler user information.
       * @apiName GetUserByIDAsync.
       * @apiGroup User
       *    
       * @apiParam {Number}  Id of the user.
       * 
       * @apiSuccess : Show particuler user details.
       */
        [HttpGet("userbyId/{Id}")]
        public async Task<IActionResult> GetUserByIDAsync([FromRoute] string Id)
        {
            return Ok(await _userRepository.GetUserByIdAsync(Id));
        }

        /**
        *   @api{post} api/UserInformation/adduser Method to add user detail.
        *   
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
         * @api {put} /UserInformation/ Modify user information.
         * @apiName UpdateUserAsync.
         * @apiGroup User
         *
         * @apiParam :{object[]} 
         * 
         * @apiUse User ID Not Found Error.
         */
        [HttpPut("updateuserdetail")]
        public async Task<ActionResult> UpdateUserAsync([FromForm] UserAC userDetail)
        {
            if (userDetail.Id == null)
            {
                return BadRequest();
            }
            await _userRepository.UpdateUserDetailAsync(userDetail);
            return Ok("Update Successfully");
        }

        /**
        * @api {put} /UserInformation/ Modify User Active or Inactive.
        * @apiName RemoveByAsync
        * @apiGroup User

        * @apiSuccessExample Success-Response:{object[]} 
        */
        [HttpPut("removebyId/{Id}")]
        public async Task<ActionResult> RemoveUserByIdAsync([FromRoute] string Id)
        {
            await _userRepository.RemoveUserByIdAsync(Id);
            return Ok("Remove Successfully");
        }
        #endregion
    }
}
