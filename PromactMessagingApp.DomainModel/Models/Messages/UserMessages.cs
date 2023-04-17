using System;
using System.ComponentModel.DataAnnotations;

namespace PromactMessagingApp.DomainModel.Models.Message
{
    public class UserMessages
    {
        [Key]
        
        public Guid Id { get; set; }

        public string TextMessage { get; set; }

        public Guid SenderId { get; set; }

        public Guid ReceiverId  { get; set; }

        public bool MessageStatus { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
