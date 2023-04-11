using Microsoft.AspNetCore.Mvc;
using PromactMessagingApp.DomainModel.ApplicationClasses;
using PromactMessagingApp.DomainModel.ApplicationClasses.MessagesAC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromactMessagingApp.Repository.Messages
{
    public interface IMessagesRepository
    {
        Task<MessagesAC> SendMessageAsync(MessagesAC messagesAc);

        Task<MessagesAC> EditMessageAsync(MessagesAC messagesAc);

        Task<MessagesAC> DeleteMessageAsync(Guid UserId, int MessageId);
        Task<MessagesAC> ReciveMessageAsync(MessagesAC messagesAc);
    }
}
