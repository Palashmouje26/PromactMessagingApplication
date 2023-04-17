using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PromactMessagingApp.Core.Hubs;
using PromactMessagingApp.DomainModel.ApplicationClasses;
using PromactMessagingApp.DomainModel.ApplicationClasses.MessagesAC;
using PromactMessagingApp.DomainModel.Models.User;
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
        *   @api{post} api/Message/adduser Method to add user detail.
        *   
        *   @apiBody {object} user message detail.
        */
        [HttpPost("sendmessage")]
        public async Task<IActionResult> SendMessageAsync(MessagesAC messagesAC)
        {
            var res = await _messagesRepository.SendMessageAsync(messagesAC);
            return Ok("Message Send Successfully");
        }
        /**
       * @api {put} /Message/ Modify User Message.
       * @apiName EditMessageAsync
       * @apiGroup message

       * @apiSuccessExample Success-Response :{object[]} 
       */
        [HttpPut("editmessage")]
        public async Task<IActionResult> EditMessageAsync(MessagesAC messagesAC)
        {
            var response = await _messagesRepository.EditMessageAsync(messagesAC);
            return Ok(response);
        }
        /**
        * @api {put} /Message/ Modify User Message Active or Inactive .
        * @apiName DeleteMessageAsync
        * @apiGroup message

        * @apiSuccessExample Success-Response:
        */
        [HttpPut("deletemessage")]
        public async Task<IActionResult> DeleteMessageAsync(string UserId, Guid MessageId)
        {
            var res = await _messagesRepository.DeleteMessageAsync(UserId, MessageId);
            return Ok(res);
        }

        /**
        * @api {get} /api/Message/all active user message show the reciver.
        * @apiName GetRecivedMessageByIdAsync.
        * @apiGroup message
        *    
        * @apiSuccess :List Of active message details.
        *  
        * @apiSuccessExample Success-Response:{object[]} :
        * 
        */
        [HttpGet("recivemessage")]
        public async Task<IActionResult> GetRecivedMessageByIdAsync(string Id)
        {
            return Ok(await _messagesRepository.ReciveMessageAsync(Id));
        }
        #endregion
    }
}


