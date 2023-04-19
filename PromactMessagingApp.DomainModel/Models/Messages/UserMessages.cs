using System;
using System.ComponentModel.DataAnnotations;

namespace PromactMessagingApp.DomainModel.Models.Message
{
    public class UserMessages
    {
        /// <summary>
        ///  Id of the User Messages.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// TextMessage is used for User Text Messages to be sent.
        /// </summary>
        public string TextMessage { get; set; }

        /// <summary>
        /// SenderId is used for user who send the message.
        /// </summary>
        public Guid SenderId { get; set; }

        /// <summary>
        /// ReceiverId is used for user who receive the message.
        /// </summary>
        public Guid ReceiverId { get; set; }

        /// <summary>
        /// MessageStatus is used for maintain user message status.
        /// </summary>
        public bool MessageStatus { get; set; }

        /// <summary>
        /// CreateDate is used for when user send or recived messages.
        /// </summary>
        public DateTime CreateDate { get; set; }

    }
}
