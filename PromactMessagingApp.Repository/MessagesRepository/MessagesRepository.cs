﻿    using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PromactMessagingApp.Core.Hubs;
using PromactMessagingApp.DomainModel.ApplicationClasses.MessagesAC;
using PromactMessagingApp.DomainModel.Models.Message;
using PromactMessagingApp.DomainModel.Models.User;
using PromactMessagingApp.Repository.Data;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// This method is used for sending the messages from one user to another and store in dbset.
        /// </summary>
        /// <param name="messagesAc">Current user is used for sending messages.</param>
        /// <returns>returns object </returns>
        public async Task<MessagesAC> SendMessageAsync(MessagesAC messagesAc)
        {
            if (messagesAc != null && (Guid.TryParse(messagesAc.SenderId, out Guid value)))
            {
                UserInformation userInfo = await _dataRepository.FirstOrDefaultAsync<UserInformation>(x => x.Id == value);

                if (userInfo != null)
                {
                    await _hubContext.Clients.Client(messagesAc.SenderId).SendAsync("SendMessage", messagesAc.ReceiverId, messagesAc.TextMessage);                  

                    UserMessages response = _mapper.Map<MessagesAC, UserMessages>(messagesAc);
                   
                    await _dataRepository.AddAsync(response);
                }
                return _mapper.Map<MessagesAC>(messagesAc);
            }
            return null;
        }

        /// <summary>
        /// This method is used for showing receiver user messages.
        /// </summary>
        /// <param name="Id">Id is used for particular user receiver.</param>
        /// <returns> return object </returns>
        public async Task<List<MessagesAC>> ReceiveMessageAsync(string Id)
        {
            if (Guid.TryParse(Id, out Guid value))
            {
                UserInformation userInfo = await _dataRepository.FirstOrDefaultAsync<UserInformation>(x => x.Id == value);

                if (userInfo != null)
                {
                    List<UserMessages> messageList = await _dataRepository.Where<UserMessages>(x => x.ReceiverId == value).ToListAsync();
                    return _mapper.Map<List<MessagesAC>>(messageList);
                }

            }
            return null;
        }

        /// <summary>
        /// This Method is used for edit messages.
        /// </summary>
        /// <param name="messagesAc">Currenmt user messages.</param>
        /// <returns>return object</returns>
        public async Task<MessagesAC> EditMessageAsync(Guid Id,MessagesAC messagesAc)
        {
            if (Id != null && Guid.TryParse(messagesAc.SenderId, out Guid senderValue) && Guid.TryParse(messagesAc.ReceiverId, out Guid receiverValue))
            {
                UserMessages userInfo = await _dataRepository.FirstOrDefaultAsync<UserMessages>(x => x.Id.Equals(messagesAc.SenderId) && x.SenderId == senderValue
                && x.ReceiverId == receiverValue);

                if (userInfo != null)
                {
                    userInfo.TextMessage = messagesAc.TextMessage;
                    await _dataRepository.UpdateAsync(userInfo);
                    throw new Exception("Message Updated");
                }
                else
                {
                    throw new Exception("Message Not Updated");
                }
            }
            return messagesAc;

        }

        /// <summary>
        /// This method is used for delete messages as true or false.
        /// </summary>
        /// <param name="UserId">Current users , userId is used for edit.</param>
        /// <param name="MessageId">Current users , messageId is used for edit.</param>
        /// <returns>return object it is true or false.</returns>
        public async Task<MessagesAC> DeleteMessageAsync(string UserId, Guid MessageId)
        {
            if (Guid.TryParse(UserId, out Guid value))
            {
                if (UserId == null || MessageId == null)
                {
                    UserMessages userInfo = await _dataRepository.FirstOrDefaultAsync<UserMessages>(x => x.SenderId == value && x.Id == MessageId);
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
            }
            return new MessagesAC();

        }
        #endregion
    }
}
