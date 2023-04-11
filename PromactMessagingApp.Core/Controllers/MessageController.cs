using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PromactMessagingApp.Core.Hubs;
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
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IMessagesRepository _messagesRepository;
        private readonly UserManager<UserInformation> userManager;
        #endregion
        #region Constructor
        public MessageController(IMapper mapper, IHubContext<ChatHub> hubContext, IMessagesRepository messagesRepository)
        {
            _mapper = mapper;
            _hubContext = hubContext;
            _messagesRepository = messagesRepository;
        }
        #endregion

        #region Public Methods
        [HttpPost("sendmessage")]
        public async Task<IActionResult> SendMessageAsync(MessagesAC messagesAC)
        {
            var res = await _messagesRepository.SendMessageAsync(messagesAC);
            return Ok();
        }

        [HttpPut("editmessage")]
        public async Task<IActionResult> EditMessageAsync(MessagesAC messagesAC)
        {
            var res = await _messagesRepository.EditMessageAsync(messagesAC);
            return Ok(res);
        }

        [HttpPut("deletemessage")]
        public async Task<IActionResult> DeleteMessage(Guid UserId, int MessageId)
        {
            var res = await _messagesRepository.DeleteMessageAsync(UserId, MessageId);
            return Ok(res);
        }

        [HttpGet("recivemessage")]
        public async Task<IActionResult> GetUserByIDAsync(MessagesAC messagesAC)
        {
            return Ok(await _messagesRepository.ReciveMessageAsync(messagesAC));
        }
        #endregion
    }
}


