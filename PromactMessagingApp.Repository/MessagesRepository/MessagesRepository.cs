using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using PromactMessagingApp.Core.Hubs;
using PromactMessagingApp.DomainModel.ApplicationClasses.MessagesAC;
using PromactMessagingApp.DomainModel.Models.Message;
using PromactMessagingApp.DomainModel.Models.User;
using PromactMessagingApp.Repository.Data;
using System;
using System.Threading.Tasks;

namespace PromactMessagingApp.Repository.Messages
{
    public class MessagesRepository : IMessagesRepository
    {
        #region Private Methods
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _hubContext;
        #endregion

        #region Constructor
        public MessagesRepository(IDataRepository dataRepository, IMapper mapper, IHubContext<ChatHub> hubContext)
        {
            _mapper = mapper;
            _dataRepository = dataRepository;
            _hubContext = hubContext;
        }
        #endregion

        #region Public Methods

        public async Task<MessagesAC> SendMessageAsync(MessagesAC messagesAc)
        {

            var userInfo = await _dataRepository.FirstOrDefaultAsync<UserInformation>(x => x.Id == messagesAc.SenderId);

            if (userInfo != null)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", messagesAc.ReceiverId, messagesAc.TextMessage);
                var response = _mapper.Map<MessagesAC, UserMessages>(messagesAc);

            
                await _dataRepository.AddAsync(response);
            }
            return _mapper.Map<MessagesAC>(messagesAc);
        }

        public async Task<MessagesAC> ReciveMessageAsync(MessagesAC messagesAc)
        {

            var userInfo = await _dataRepository.FirstOrDefaultAsync<UserInformation>(x => x.Id == messagesAc.SenderId);

            if (userInfo != null)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", messagesAc.ReceiverId, messagesAc.TextMessage);
                var response = _mapper.Map<MessagesAC, UserMessages>(messagesAc);

                await _dataRepository.AddAsync(response);
            }
            return _mapper.Map<MessagesAC>(messagesAc);
        }

        public async Task<MessagesAC> EditMessageAsync(MessagesAC messagesAc)
        {
            var userInfo = await _dataRepository.FirstOrDefaultAsync<UserMessages>(x => x.SenderId == messagesAc.SenderId && x.ReceiverId == messagesAc.ReceiverId);

            if (userInfo != null)
            {
                userInfo.TextMessage = messagesAc.TextMessage;
                await _dataRepository.UpdateAsync(userInfo);
                throw new Exception("Message Updates");
            }
            else
            {
                throw new Exception("Message Not Updated");
            }

        }

        public async Task<MessagesAC> DeleteMessageAsync(Guid UserId, int MessageId)
        {
            var userInfo = await _dataRepository.FirstOrDefaultAsync<UserMessages>(x => x.SenderId == UserId && x.Id == MessageId);

            if (userInfo != null)
            {
                userInfo.MessageStatus = false;
                await _dataRepository.UpdateAsync(userInfo);
                throw new Exception("Message Deleted");
            }
            else
            {
                throw new Exception("Message Not Deleted");
            }
        }
        #endregion
    }
}
