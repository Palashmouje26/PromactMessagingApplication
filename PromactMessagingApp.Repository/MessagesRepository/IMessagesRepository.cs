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
        /// <summary>
        /// This method is used for send messages and save in dbset.
        /// </summary>
        /// <param name="messagesAc">Current user message details</param>
        /// <returns>return object</returns>
        Task<MessagesAC> SendMessageAsync(MessagesAC messagesAc);
        /// <summary>
        /// This is used for edited the message.
        /// </summary>
        /// <param name="messagesAc"> Current user message edit</param>
        /// <returns></returns>
        Task<MessagesAC> EditMessageAsync(Guid Id,MessagesAC messagesAc);

        /// <summary>
        /// This method is for remove the unnecessary message.
        /// </summary>
        /// <param name="UserId">current senderId is used</param>
        /// <param name="MessageId">current messageId is used</param>
        /// <returns>rturn message true or false</returns>
        Task<MessagesAC> DeleteMessageAsync(string UserId, Guid MessageId);

        /// <summary>
        /// This method is used for send the message to the sender.
        /// </summary>
        /// <param name="Id">Current reciverId is used.</param>
        /// <returns>return object</returns>
        Task<List<MessagesAC>> ReceiveMessageAsync(string Id);

    }
}
