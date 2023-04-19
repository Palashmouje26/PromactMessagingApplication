using Microsoft.AspNetCore.Mvc;
using PromactMessagingApp.DomainModel.ApplicationClasses.MessagesAC;
using PromactMessagingApp.Repository.Messages;
using System;
using System.Threading.Tasks;

namespace Promact_Messaging_Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        #region Private Methods
        private readonly IMessagesRepository _messagesRepository;
        #endregion

        #region Constructor
        public MessageController( IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }
        #endregion

        #region Public Methods

        /**
        *   @api {post} /message/:method is used for sending messages to the selected user.
        *   
        *   @apiParam {String} MessagesAC Object.
        *   
        *   @apiBody {object} user message detail.
        *   
        *   @apiSuccess::{object[]} 
        */
        [HttpPost("sendmessage")]
        public async Task<IActionResult> SendMessageAsync([FromBody] MessagesAC messagesAC)
        {
            var res = await _messagesRepository.SendMessageAsync(messagesAC);
            if(res == null)
            {
                return BadRequest("Not Implemented");
            }
            return Ok("Message Send Successfully");
        }

        /**
        * @api {put} / message/:Id is used for updating user message.
        * @apiName EditMessageAsync.
        * @apiGroup message
        * 
        * @apiParam {Number} Id is used for unique message Id.
        * @apiParam {String} MessagesAc Object. 
        * 
        * @apiSuccessExample Success-Response :{object[]} 
        */
        [HttpPut("editmessage")]
        public async Task<IActionResult> EditMessageAsync([FromRoute] Guid Id,MessagesAC messagesAC)
        {
            var response = await _messagesRepository.EditMessageAsync(Id,messagesAC);
            return Ok(response);
        }

        /**
        * @api {put} /message/:deleting user send message.
        * @apiName DeleteMessageAsync.
        * @apiGroup message
        * 
        * @apiParam {Number} UserId is used of a user.
        * @apiParam {Number} MessageID Is used of delete particuler message.
        * 
        * @apiSuccessExample Success-Response:{object[]} 
        */

        [HttpPut("deletemessage")]
        public async Task<IActionResult> DeleteMessageAsync([FromRoute] string UserId, Guid MessageId)
        {
            var res = await _messagesRepository.DeleteMessageAsync(UserId, MessageId);
            return Ok(res);
        }

        /**
        * @api {get}/ message/:Id get all  user recevier messages show the reciver.
        * @apiName GetRecivedMessageByIdAsync.
        * @apiGroup message
        *    
        * @paiParam: Id is used for user.
        * 
        * @apiSuccess :user receiver all message show.
        *  
        * @apiSuccessExample Success-Response:{object[]} :
        * 
        */

        [HttpGet("recivemessage/{Id}")]
        public async Task<IActionResult> GetRecivedMessageByIdAsync([FromRoute] string Id)
        {
            return Ok(await _messagesRepository.ReceiveMessageAsync(Id));
        }
        #endregion
    }
}


