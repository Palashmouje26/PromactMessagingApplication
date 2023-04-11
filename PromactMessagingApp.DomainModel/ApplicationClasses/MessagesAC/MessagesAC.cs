﻿using PromactMessagingApp.DomainModel.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PromactMessagingApp.DomainModel.ApplicationClasses.MessagesAC
{
    public class MessagesAC
    {
        public int Id { get; set; }

        public string TextMessage { get; set; }

        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public bool MessageStatus { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
